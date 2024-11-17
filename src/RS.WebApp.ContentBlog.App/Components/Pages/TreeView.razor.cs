using Microsoft.AspNetCore.Components;

namespace RS.WebApp.ContentBlog.App.Components.Pages;

public partial class TreeView : ComponentBase
{
    private readonly string folderPath = @"wwwroot\files"; // Folder path to load files and directories
    private string[] directories = [];
    private string[] files = [];
    private string errorMessage = string.Empty;
    private string SelectedFileName = string.Empty;

    protected override void OnInitialized()
    {
        // Load the directories and files
        LoadFolderContents(folderPath);
    }

    private void LoadFolderContents(string path)
    {
        try
        {
            if (Directory.Exists(path))
            {
                directories = Directory.GetDirectories(path);
                files = Directory.GetFiles(path);
            }
            else
            {
                errorMessage = $"Directory '{path}' does not exist.";
            }
        }
        catch (Exception ex)
        {
            errorMessage = $"Error loading directory: {ex.Message}";
        }
    }

    private void LoadSelectedFile(string filePath)
    {
        SelectedFileName = string.Join("\\", filePath.Split("\\").Skip(2));
        StateHasChanged(); // Notify the UI that the component has finished loading
    }
}
