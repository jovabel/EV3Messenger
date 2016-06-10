# How To Use

Because of time contrains the documentation is not yet complete, but it should be enough to get you up and running.

You need a working bluetooth connection from your windows PC to the Lego Mindstorms EV3 robot. 
The PC should set up the bluetooth connection and should be master. To do so,
* Make sure you did not make any bluetooth connection from within the Lego Mindstorms EV3 programming environment. If you did, then close that connection.
* Make sure bluetooth is enabled on the EV3 and your PC.
* Find the EV3 robot from your PC using windows (Start>Devices And Printers>Add device)
* Connect (A dialog should appear on the EV3).
* On the EV3, accept the connection and note the showed paircode. 
* The PC should show a pair code dialog now. Enter the pair code on the PC. If windows shows you a dialog to enter the pair code before the EV3 showed the pair code, then cancel and try again.
voila... 

## Programming / using the source code
All source code to rebuild the EV3Messenger executable is provided. Visual Studio 2010 (ultimate) was used to develop and build the projects. Higher versions of Visual Studio should also be able to rebuild the projects.

_If you re-use the source, then please be so kind to mention my name and provide a link to this web site_.

The source code is split into 2 projects:
* EV3Messenger, which contains a Windows Forms app that can be used to test the exchanging of messages between a PC and an Lego Mindstorms EV3. The app is only a thin UI layer on top of the EV3MessengerLib.
* EV3MessengerLib, which contains code that does the real work (message sending, receiving, parsing, creating payloads, etc).

The EV3MessengerLib contains 2 public classes for communicating with the EV3.
* The class [EV3Messenger](src/EV3MessengerLib/EV3Messenger.cs) provides the communication functionality. It has methods to connect to the Lego EV3 robot and provides methods to send and receive messages. The available message types are text (string), numbers (float) and logic values (boolean).
* The class [EV3Message](src/EV3MessengerLib/EV3Message.cs) represents an exchanged message.

## The protocol
The protocol used is described in [FieldInfo.cs](src/EV3MessengerLib/Protocol/FieldInfo.cs).

The protocol of the current (and working) EV3Messenger version was derived by sniffing the serial-over-bluetooth connection of a Mindstorms EV3 that was connected to a PC.

At the moment the Mindstorms EV3 source code is being investigated to make an even better :-) implementation of the protocol. 

## The C# application
The EV3Messenger project contains a Windows Forms program that runs out-of-the-box.

## Lego Mindstorms EV3 sample code
The ev3 directory in the source repos contains a Lego Mindstorms EV3 program that sends and receives messages. You can use it to test the EV3Messenger application and your bluetooth connection.


