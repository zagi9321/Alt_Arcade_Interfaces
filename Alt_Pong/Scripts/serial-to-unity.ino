const int left = 2;
const int right = 4;
int buttonStateL = 0;
int buttonStateR = 0;
const int ledPinL = 13;

void setup() {
  Serial.begin(9600);

  pinMode(left, INPUT_PULLUP);
  pinMode(right, INPUT_PULLUP);
  pinMode(ledPinL, OUTPUT);
}

void loop() {
  buttonStateL = digitalRead(left);
  buttonStateR = digitalRead(right);
  
  if((!buttonStateL && buttonStateR) || (buttonStateL && !buttonStateR)){
    Serial.flush();
    Serial.println(0);
  }
  else if(buttonStateL && buttonStateR){
    Serial.flush();
    Serial.println(1);
  }
  else if(!buttonStateL && !buttonStateR) {
    Serial.flush();
    Serial.println(2);
  }

  delay(10);
}