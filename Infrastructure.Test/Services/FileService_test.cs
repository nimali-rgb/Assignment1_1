

using Infrastructure.Interfaces;
using Infrastructure.Models;
using Moq;
using System.Net.Http.Json;

namespace Infrastructure.Test.Services;

public class FileService_test
{
    [Fact]
    public void SaveContentToFile_ShouldReturnTrue_WhenContenetSavedToFile()
    {
        //Arrange
        var fileResult = new FileResult { Succeeded = true };


        var fileServiceMock = new Mock<IFileService>();
        var fileService = fileServiceMock.Object;

        fileServiceMock.Setup(fs => fs.SaveContentToFile(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(fileResult);

        //Act

        var result = fileService.SaveContentToFile("","");

        //Assert
        Assert.True(result.Succeeded );
    }

    [Fact]
    public void SaveContentToFile_ShouldReturnFalseWithError_WhenContenetIsNotSavedToFile()
    {
        //Arrange
        var fileResult = new FileResult { Succeeded = false, Error = "Unable to save content." };


        var fileServiceMock = new Mock<IFileService>();
        var fileService = fileServiceMock.Object;

        fileServiceMock.Setup(fs => fs.SaveContentToFile(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(fileResult);

        //Act

        var result = fileService.SaveContentToFile("", "");

        //Assert
        Assert.False(result.Succeeded);
        Assert.Equal("Unable to save content.", result.Error);
    }


    [Fact]
    public void GetContentFromFile_ShouldReturnTrueAndContentAsJson_WhenFileFound()
    {
        //Arrange
        var jsonContent = "[{ \"Id\": \"775baeb7 - 5a53 - 474f - a55f - 553a67966aaa\", \"Name\": \"Test Product\", \"Price\" : 100.00 }]";
        var fileResult = new FileResult { Succeeded = true, Content = jsonContent };


        var fileServiceMock = new Mock<IFileService>();
        var fileService = fileServiceMock.Object;

        fileServiceMock.Setup(fs => fs.GetContentFromFile(It.IsAny<string>())) 
            .Returns(fileResult);

        //Act
        var result = fileService.GetContentFromFile("");


        //Assert
        Assert.True(result.Succeeded);
        Assert.Equal(jsonContent, result.Content);
    }



    [Fact]
    public void GetContentFromFile_ShouldReturnTrueAndEmptyString_WhenNoFileFound()
    {
        //Arrange
       
        var fileResult = new FileResult { Succeeded = true, Content = "" };


        var fileServiceMock = new Mock<IFileService>();
        var fileService = fileServiceMock.Object;

        fileServiceMock.Setup(fs => fs.GetContentFromFile(It.IsAny<string>()))
            .Returns(fileResult);

        //Act
        var result = fileService.GetContentFromFile("");


        //Assert
        Assert.True(result.Succeeded);
        Assert.Equal("", result.Content);
    }


    [Fact]
    public void GetContentFromFile_ShouldReturnFalseWithError_WhenExceptionOccured()
    {
        //Arrange

        var fileResult = new FileResult { Succeeded = false, Error = "Something went wrong!" };


        var fileServiceMock = new Mock<IFileService>();
        var fileService = fileServiceMock.Object;

        fileServiceMock.Setup(fs => fs.GetContentFromFile(It.IsAny<string>()))
            .Returns(fileResult);

        //Act
        var result = fileService.GetContentFromFile("");


        //Assert
        Assert.False(result.Succeeded);
        Assert.False(string.IsNullOrEmpty(result.Error));
    }
}

