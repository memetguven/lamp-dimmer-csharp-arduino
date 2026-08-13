const int zeroCrossPin = 2;
const int triacPin = 9;
volatile int brightness = 50;   

void setup() {
  pinMode(zeroCrossPin, INPUT);
  pinMode(triacPin, OUTPUT);
  digitalWrite(triacPin, LOW);

  attachInterrupt(digitalPinToInterrupt(zeroCrossPin), zeroCrossISR, RISING);
  Serial.begin(9600);
}

void loop() {
  if (Serial.available() > 0)
  {
    String data = Serial.readStringUntil('\n');
    int value = data.toInt();
    if (value >= 0 && value <= 100)
    {
      brightness = value;
    }
  }
}

void zeroCrossISR() {
   if (brightness <= 0)
  {
    return;
  }

  int delayTime;

if (brightness < 90) 
  {
    delayTime = map(brightness, 1, 90, 7600, 3800);
  } 
  else 
  {   
    delayTime = map(brightness, 91, 100, 3800, 2800);
  }

  delayMicroseconds(delayTime);
  digitalWrite(triacPin, HIGH);
  delayMicroseconds(100);
  digitalWrite(triacPin, LOW);
}
