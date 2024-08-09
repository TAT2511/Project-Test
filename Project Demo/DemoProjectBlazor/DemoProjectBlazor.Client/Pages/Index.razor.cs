using DemoProjectBlazor.Server.Data;
using System.Net.Http.Json;

namespace DemoProjectBlazor.Client.Pages
{
	public partial class Index
	{
		private List<AlumniCuuSv> dsCuuSinhVien = new List<AlumniCuuSv>();
		private List<AlumniThongTinDaoTao> ThongTinDaoTaoList = new List<AlumniThongTinDaoTao>(); 
		private List<AlumniQuyetDinhDaoTao> QuyetDinhDaoTaoList = new List<AlumniQuyetDinhDaoTao>();
		int CurrentPage = 1;
		int PageSize = 10;
		int TotalItems;
		int TotalPages;

		private bool isDeleting = false;
		private Guid itemToDelete;
		protected override async Task OnInitializedAsync()
		{
			await Task.Delay(100);
			await LoadData();
			//var CuuSVList = await Http.GetFromJsonAsync<List<AlumniCuuSv>>("api/index?page=" + CurrentPage);
			//var ThongTinDaoTaoList = await Http.GetFromJsonAsync<List<AlumniThongTinDaoTao>>("api/index/thongtindaotao");
			//var QuyetDinhDaoTaoList = await Http.GetFromJsonAsync<List<AlumniQuyetDinhDaoTao>>("api/index/quyetdinhdaotao");
			//dsCuuSinhVien = CuuSVList ?? new List<AlumniCuuSv>();

		}
		private async Task LoadData()
		{
			var response = await Http.GetFromJsonAsync<List<AlumniCuuSv>>($"api/index?page={CurrentPage}");
			dsCuuSinhVien = response ?? new List<AlumniCuuSv>();

			// Lấy số lượng mục và tính số trang
			TotalItems = dsCuuSinhVien.Count;
			TotalPages = (int)Math.Ceiling((double)TotalItems / PageSize);
		}
		private void ConfirmDelete(Guid id)
		{
			itemToDelete = id;
			isDeleting = true;
		}

		private async Task Delete()
		{
			var response = await Http.DeleteAsync($"api/cuusingvien/{itemToDelete}");
			if (response.IsSuccessStatusCode)
			{
				var result = await Http.GetFromJsonAsync<List<AlumniCuuSv>>("api/cuusingvien");
				dsCuuSinhVien = result ?? new List<AlumniCuuSv>(); // Nếu result là null, khởi tạo danh sách trống
			}
			else
			{
				// Xử lý lỗi nếu cần thiết
				Console.WriteLine("Error deleting item");
			}

			isDeleting = false; // Đóng hộp thoại xác nhận
		}

		private void CancelDelete()
		{
			isDeleting = false; // Đóng hộp thoại xác nhận mà không thực hiện xóa
		}

		//Nút bật tắt tìm kiếm nâng cao 
		private bool isSearchFormOpen = true;
		private void ToggleSearchForm()
		{
			isSearchFormOpen = !isSearchFormOpen;
		}
		// Phương thức xử lý chuyển trang
		private async Task LoadPage(int page)
		{
			if (page >= 1 && page <= TotalPages)
			{
				CurrentPage = page;
				await LoadData();
			}
		}
	}
}
