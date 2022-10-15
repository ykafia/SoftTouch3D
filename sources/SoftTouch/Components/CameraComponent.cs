using System.Numerics;

namespace SoftTouch.Components;


public struct Camera 
{
    public Vector3 Eye = new(0,0,1);
    public Vector3 Target = new(0,0,0);
    public Vector3 up = new(0,1,0);
    public float Aspect = 16/9;
    public float FovY = 45;
    public float ZNear = 0.001f;
    public float ZFar = 1000;

    public Camera(){}
}