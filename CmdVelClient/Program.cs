using System.Threading.Tasks;
using Grpc.Net.Client;
using CmdVelClient;

// Create gRPC client
using var channel = GrpcChannel.ForAddress("http://127.0.0.1:5254");
var client = new KinematicsCalc.KinematicsCalcClient(channel);

// Send rpc call to WheelKinematics
var reply = await client.CalcDiffDriveAsync(
    new CmdVel {
        X = 0.2,
        Th = 0.3
    }
);

Console.WriteLine($"Robot: ({reply.Robot.X}, {reply.Robot.Y}, {reply.Robot.Th})");
Console.WriteLine($"Left:  {reply.Left.Lin} m/s at {reply.Left.Ang} rad/s");
Console.WriteLine($"Right: {reply.Right.Lin} m/s at {reply.Right.Ang} rad/s");
Console.WriteLine("press any key to exit");
Console.ReadKey();