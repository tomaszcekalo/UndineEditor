
using Undine.DefaultEcs;

using var game = new SampleGame.Game1()
{
    EcsContainer=new DefaultEcsContainer()
};
game.Run();
