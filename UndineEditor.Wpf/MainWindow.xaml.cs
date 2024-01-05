using Microsoft.Xna.Framework;
using SampleGame;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Undine.Core;
using Undine.MonoGame;
using Undine.MonoGame.Primitives2D;

namespace UndineEditor.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Thread myThread = new Thread(new ThreadStart(StartGame));
            myThread.Start();
        }
        public Game1 Game { get; private set; }

        public void StartGame()
        {
            Game = new Game1()
            {
                EditorEntities = new List<EditorEntity>() 
                { 
                    new EditorEntity() 
                    { 
                        Components=new Dictionary<Type, object>()
                        {
                            {
                                typeof(TransformComponent), new TransformComponent()
                                {
                                    Origin = new Vector2(5, 5),
                                    Position = new Vector2(10, 10),
                                    Scale = Vector2.One
                                }
                            },
                            {
                                typeof(Primitives2DComponent), new Primitives2DComponent()
                                {
                                    Color = Color.Orange,
                                    DrawType = Primitives2DDrawType.DrawCircle,
                                    Size = new Vector2(10, 10),
                                    Thickness = 5,
                                    Sides = 64,
                                }
                            }
                        }
                    }
                }
            };
            Game.Run();

            //var entity = EcsContainer.CreateNewEntity();
            //entity.AddComponent(new TransformComponent()
            //{
            //    Origin = new Vector2(5, 5),
            //    Position = new Vector2(10, 10),
            //    Scale = Vector2.One
            //});
            //entity.AddComponent(new Primitives2DComponent()
            //{
            //    Color = Color.Orange,
            //    DrawType = Primitives2DDrawType.DrawCircle,
            //    Size = new Vector2(10, 10),
            //    Thickness = 10,
            //    Sides = 64,
            //});
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Game.Exit();
        }
    }
}