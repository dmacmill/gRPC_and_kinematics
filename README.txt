an ASP.Net gRPC project for calculating wheel kinematics of a 
differential drive robot.

Build the client first with $dotnet build, then build/run the 
WheelKinematics server, then run the client.

Could be the foundation for a gRPC + godot robot simulation with 
controller or simulated joystick providing input for the robot 
in godot engine. To do this, would need to setup the rpc channels 
to be one-way from controller to WheelKinematics - to avoid 
waiting. 