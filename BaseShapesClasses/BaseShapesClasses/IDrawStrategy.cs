using System.Windows.Shapes;

namespace BaseShapesClasses;


public interface IDrawStrategy
{
    Shape DrawShape(AbstractShape abstractShape);
}
