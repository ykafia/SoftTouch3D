using MessagePack.Resolvers;

namespace SoftTouch.Games;


public class MyGame : Game
{
    public MyGame() : base(Assets.SoftTouchResolver.Instance, StandardResolver.Instance)
    {

    }
}