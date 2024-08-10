﻿using Azure;
using DemoProjectBlazor.Server.Data;
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

		private async Task Delete()
		{
			var response = await Http.DeleteAsync($"api/cuuSinhVien/{itemToDelete}");
			if (response.IsSuccessStatusCode)
			{
				await LoadData(CurrentPage);
			}
			else
			{
				Console.WriteLine("Error deleting item");
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

	}
}
