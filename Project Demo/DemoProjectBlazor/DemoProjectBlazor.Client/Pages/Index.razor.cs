using Azure;
using DemoProjectBlazor.Server.Data;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace DemoProjectBlazor.Client.Pages
{
	public partial class Index
	{
		private List<AlumniCuuSv> dsCuuSinhVien = new();
		private int CurrentPage = 1;
		private int PageSize = 5;
		private int TotalItems;
		private int TotalPages;

		private bool isDeleting = false;
		private Guid itemToDelete;

		private List<Guid> selectedIds = new();
		private bool isDeletingSelected = false;
		protected override async Task OnInitializedAsync()
		{
			await LoadData(CurrentPage);
		}

		private async Task LoadData(int page)
		{
			var response = await Http.GetFromJsonAsync<List<AlumniCuuSv>>($"api/cuuSinhVien?page={page}&pageSize={PageSize}");
			dsCuuSinhVien = response ?? new List<AlumniCuuSv>();

			TotalItems = await Http.GetFromJsonAsync<int>("api/cuuSinhVien/count");
			TotalPages = (int)Math.Ceiling((double)TotalItems / PageSize);
		}

		private async Task LoadPage(int page)
		{
			Console.WriteLine($"Loading page {page}");  
			if (page >= 1 && page <= TotalPages)
			{
				CurrentPage = page;
				await LoadData(page);
				StateHasChanged();    
			}
		}	

		private bool isSearchFormOpen = true;
		private void ToggleSearchForm()
		{
			isSearchFormOpen = !isSearchFormOpen;
		}

		//Chọn check tất cả checkbox
		private void ToggleSelectAll(ChangeEventArgs e)
		{
			var isChecked = e.Value as bool?;

			if (isChecked.HasValue)
			{
				if (isChecked.Value)
				{
					selectedIds = dsCuuSinhVien?.Select(sv => sv.Id).ToList() ?? new List<Guid>();
				}
				else
				{
					selectedIds?.Clear();
				}
			}
		}

		private void ToggleSelection(Guid id, ChangeEventArgs e)
		{
			var isChecked = e.Value as bool?;

			if (isChecked.HasValue)
			{
				if (selectedIds != null)
				{
					if (isChecked.Value)
					{
						if (!selectedIds.Contains(id))
						{
							selectedIds.Add(id);
						}
					}
					else
					{
						selectedIds.Remove(id);
					}
				}
			}
		}
		//Popup Xóa 1 hay nhiều sinh viên trong checkbox đã chọn
		private async Task DeleteSelected()
		{
			// Kiểm tra nếu không có ID nào được chọn
			if (!selectedIds.Any())
			{
				return;
			}
			// Hiển thị thông báo xác nhận
			isDeletingSelected = true;
			await Task.Yield();
		}

		private async Task ConfirmDeleteSelected()
		{
			foreach (var id in selectedIds)
			{
				var response = await Http.DeleteAsync($"api/cuuSinhVien/{id}");
				if (!response.IsSuccessStatusCode)
				{
					Console.WriteLine($"Error deleting item with ID {id}");
				}
			}

			// Tải lại dữ liệu và đóng modal
			await LoadData(CurrentPage);
			isDeletingSelected = false;
			selectedIds.Clear();
		}

		private void CancelDeleteSelected()
		{
			isDeletingSelected = false;
		}

		
		//Popup xóa 1 sinh viên 
		private async Task Delete()
		{
			var response = await Http.DeleteAsync($"api/cuuSinhVien/{itemToDelete}");
			if (response.IsSuccessStatusCode)
			{
				await LoadData(CurrentPage);
			}
			else
			{
				Console.WriteLine("Lỗi không xóa được sinh viên");
			}

			isDeleting = false;
		}
		private void ConfirmDelete(Guid id)
		{
			itemToDelete = id;
			isDeleting = true;
		}
		private void CancelDelete()
		{
			isDeleting = false;
		}
		//Lấy detail thông tin sinh viên lên popup
		private bool isInfoPopupOpen = false;
		private AlumniCuuSv? selectedStudent; 

		private async Task ShowInfoPopup(Guid maSV)
		{
			try
			{
				var sv = await Http.GetFromJsonAsync<AlumniCuuSv>($"api/cuuSinhVien/{maSV}");

				if (sv != null)
				{
					selectedStudent = sv;
					isInfoPopupOpen = true;
				}
				else
				{
					Console.WriteLine("Không thể lấy thông tin sinh viên. Dữ liệu trả về là null.");
				}
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Lỗi khi lấy thông tin sinh viên: {ex.Message}");
			}
		}

		private void CloseInfoPopup()
		{
			selectedStudent = null;
			isInfoPopupOpen = false;
		}

		private string? searchQuery;
		private string? selectedGender;
		private async Task OnSearchAsync()
		{
			var queryParams = new List<string>();

			if (!string.IsNullOrEmpty(selectedGender))
			{
				queryParams.Add($"sex={selectedGender}");
			}

			if (!string.IsNullOrEmpty(searchQuery))
			{
				queryParams.Add($"searchQuery={searchQuery}");
			}

			var queryString = string.Join("&", queryParams);
			var response = await Http.GetFromJsonAsync<List<AlumniCuuSv>>($"api/cuuSinhVien/Filter?{queryString}&page={CurrentPage}&pageSize={PageSize}");

			dsCuuSinhVien = response ?? new List<AlumniCuuSv>();

			// Kiểm tra header để lấy số lượng tổng
			var totalCountHeader = Http.DefaultRequestHeaders.GetValues("X-Total-Count").FirstOrDefault();
			TotalItems = !string.IsNullOrEmpty(totalCountHeader) ? int.Parse(totalCountHeader) : 0;
			TotalPages = (int)Math.Ceiling((double)TotalItems / PageSize);

			StateHasChanged();
		}
	}
}
