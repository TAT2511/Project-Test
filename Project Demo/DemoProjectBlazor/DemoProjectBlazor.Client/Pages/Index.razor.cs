using DemoProjectBlazor.Server.Data;
using System.Net.Http.Json;

namespace DemoProjectBlazor.Client.Pages
{
	public partial class Index
	{
		private List<AlumniCuuSv> dsCuuSinhVien = new List<AlumniCuuSv>();
		private bool isDeleting = false;
		private Guid itemToDelete;
		protected override async Task OnInitializedAsync()
		{
			await Task.Delay(100);
			var data = await Http.GetFromJsonAsync<List<AlumniCuuSv>>("api/cuuSinhVien");
			dsCuuSinhVien = data ?? new List<AlumniCuuSv>();

		}

		private void ConfirmDelete(Guid id)
		{
			itemToDelete = id;
			isDeleting = true;
		}

		private async Task DeleteAlumni()
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
	}
}
