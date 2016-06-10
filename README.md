# EV3Messenger

The EV3 Messenger is a C# program for exchanging messages with a Lego Mindstorms EV3 robot using Bluetooth.

## How to use

* Create a bluetooth connection between your computer and the Lego Mindstorms EV3 robot (using windows, not using the Mindstorms EV3 program environment) 
* Check which serial port is used by the connection (find the properties in the 'Start Menu -> Device and printers' dialog.
* Create a program on your EV3 robot that uses message blocks and wait for message blocks (actually the wait blocks have a better use, especially in update mode)
* Run the EV3Messenger program....

Notes
* Lego did not release the bluetooth protocol of the EV3 yet. So this program was made after sniffing the serial communication. It's a functional proof of concept :-)
* Direct commands are not supported.

A short doc file that should get you up and running with the code can be found [here](DOCS.md)

More to follow.... need some time (who doesn't)!

Have fun!  
Joeri van Belle
  
# News
**10-6-2016**  
Moved from CodePlex to GitHub

**19-10-2013**  
Article in [Bot Bench](http://botbench.com) : [Talking to your EV3](http://botbench.com/blog/2013/10/19/talking-to-your-ev3-ev3messenger) by Xander Soldaat

