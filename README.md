F1_201x_TelemetrySystem
=======================

Real Time Telemetry System for F1 2012 Series

Used the project https://github.com/robgray/F1Speed as a base and extended it to make real time graphics of 
the data collected

Installation:

F1_201x_TelemetrySystem needs .NET 4.0 installed.  .NET 4.0 is a recommended update for Vista and Windows 7 so hopefully most people have it installed, if not you can download the 30MB .NET 4.0 client profile.  When you click on the Install button below you be asked to download setup.exe which will launch the bootstrapper and install the rest of the application from the web. It's tiny, so doens't take long and because it's a ClickOnce app it'll notify you whenever it's updated!

The most important step is to configure the link between F1 2012/2011/2010 and F1Speed.  F1 2011 publishes telemetry data via UDP and we need to tell F1 2012/2011/2010 to use F1Speed as the telemetry destination. To do this you need to change your files.

To do this first ensure F1 2012/2011/2010 is closed, and then open the file "hardware_settings_config.xml". This is found in your My Documents folder in the subpath./My Games/FormulaOne2011/hardwaresettings/.

Open the file in your favourite text editor and change the line

"<motion enabled="true" ip="127.0.0.1" port="20777" delay="1" extradata="1" />"

Just to be clear, use a text editor like notepad.  Don't open the file in something like word and try and convert it around.  It'll only lead to tears (as a few guys have found out).

Once this change has been made be sure to mark the file as 'read-only' or F1 2012/2011/2010 will overwrite your changes. Marking the file as readonly will not effect the game in any way.

The original version (Called F1Speed) can be found here: http://www.robertgray.net.au/pages/f1-speed
