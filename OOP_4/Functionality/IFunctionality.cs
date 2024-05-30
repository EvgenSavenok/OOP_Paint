using BaseShapesClasses;

namespace OOP_3.Functionality;

public interface IFunctionality
{
    public string GetName { get; }
    public void SaveToFile(List<AbstractShape> abstractShapes);
    public List<AbstractShape> LoadFile(List<AbstractShape> abstractShapes, Dictionary<int, IShapeFactory> dictionary);
}
