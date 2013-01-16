F1_201x_TelemetrySystem
=======================

# Real Time Telemetry System for F1 2012 Game Series

Extension of F1Speed (https://github.com/robgray/F1Speed) that let players examine real time and historic data as charts.

You will be able to see real time graph with informations like Speed, RPM, Suspension height, Time Difference between the current and the Best Lap at each point of the circuit ....

Made for those who love tuning each parameter of the car.

# Installation:

F1_201x_TelemetrySystem needs .NET 4.0 installed. .NET 4.0 is a recommended update for Vista and Windows 7 so hopefully most people have it installed

The most important step is to configure the link between F1 2012/2011/2010 and F1_201x_TelemetrySystem.  F1 2011 publishes telemetry data via UDP and we need to tell F1 2012/2011/2010 to use F1_201x_TelemetrySystem as the telemetry destination. To do this you need to change your files.

To do this first ensure F1 2012/2011/2010 is closed, and then open the file "hardware_settings_config.xml". This is found in your My Documents folder in the subpath./My Games/FormulaOne2011/hardwaresettings/.

Open the file in your favourite text editor and change the line


  `<motion enabled="true" ip="127.0.0.1" port="20777" delay="1" extradata="1" />`

Just to be clear, use a text editor like notepad.  Don't open the file in something like word and try and convert it around.  It'll only lead to tears (as a few guys have found out).

Once this change has been made be sure to mark the file as 'read-only' or F1 2012/2011/2010 will overwrite your changes. Marking the file as readonly will not effect the game in any way.

The original (and the base) version (Called F1Speed) for this program can be found here: http://www.robertgray.net.au/pages/f1-speed

The binaries (in a *.rar format) can be found on the folder Releases, just unrar it and double click on F1SpeedDashBoard.exe
