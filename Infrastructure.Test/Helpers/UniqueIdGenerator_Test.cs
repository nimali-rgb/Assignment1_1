

using Infrastructure.Helpers.VG;


namespace Infrastructure.Test.Helpers;

public class UniqueIdGenerator_Test
{
    [Fact]
    public void Generate_ShouldReturnGuidAsString_Whensuccessful()
    {

        //Act
        string result = UniqueIdGenerator.Generate();

        var response= Guid.TryParse(result,out _);

        //Assert
        Assert.True(Guid.TryParse(result, out Guid id));
        Assert.IsType<Guid>(id);

    }
}
