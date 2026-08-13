# 220V Lamp Dimmer (Arduino + C# WinForms)

A desktop application that controls the brightness of a 220V incandescent
lamp via serial communication with an Arduino, using TRIAC phase-cut dimming.

⚠️ HIGH VOLTAGE WARNING:
This project involves working with 220V AC electricity. High voltage can be lethal. Ensure all connections are properly insulated and power is disconnected before touching any components. Proceed at your own risk.

## How it works
- The Arduino detects the AC zero-crossing point and fires the TRIAC after
  a calculated delay, controlling how much of each half-cycle reaches the lamp.
- The C# WinForms app lets the user pick a COM port, connect, and adjust
  brightness with a slider — each change is sent to the Arduino over serial (9600 baud).

## Hardware
- Arduino (Uno/Nano)
- Zero-cross detection circuit
- MOC3021 optotriac + TRIAC (e.g. BT136)
- 220V incandescent lamp

## Software
- C# / .NET (Windows Forms)
- Arduino C++ (.ino)

## Demo
https://github.com/user-attachments/assets/a813cbc4-9e00-4193-a975-8fb512723deb

<img width="6000" height="6029" alt="dimmer 2" src="https://github.com/user-attachments/assets/6f24f83a-bb7f-4b9a-a476-788f789ddcbe" />

<img width="1142" height="733" alt="dimmer 3" src="https://github.com/user-attachments/assets/4665d50e-d85b-4482-ac0c-24fc44198d44" />
