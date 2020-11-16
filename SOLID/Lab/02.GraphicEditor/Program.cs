using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            GraphicEditor editor = new GraphicEditor();

            Console.WriteLine(editor.DrawShape(new Rectangle()));
        }
    }
}
