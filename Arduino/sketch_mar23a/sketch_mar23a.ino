

#include <SFE_BMP180.h>
#include <Wire.h>
#define ledPin 6
SFE_BMP180 tmp;
String sdata = "";
typedef unsigned char U8;
U8 setPoint = 18;
int incomingByte = 0;

/*##############################################################################################*/
// Function for detecting the temperature

U8 ReadTemp()  {
  U8 status;
  double T;

  status = tmp.startTemperature();

  if (status != 0)
  {
    // Waiting for the measurement to be completed
    delay(status);
    //Measurement saved in T
    // Function returns 1 if successful and 0 if failure.

    status = tmp.getTemperature(T);
    if (status != 0)
    {
      //If status is different from 0 function returns temperature through T
      //Serial.print(" deg C, "); IF needed

      return T;
    }

  }

}


/*##############################################################################################*/
//Void function used for switching On/Off the light using a boolean var.

void setVoltage( bool state ) {
  digitalWrite(ledPin, state);
  //INVERTED VALUES- setVoltage(0) = 1,setVoltage(1) = 0;
}


/*##############################################################################################*/
void setup() {


  pinMode(ledPin, OUTPUT);
  Serial.begin(9600);
  Serial.println("REBOOT");


  // Sensor initialization
  if (tmp.begin())
    Serial.println("Senzorul BMP180 este initializat cu success");
  else
  {

    Serial.println("Senzorul BMP180 nu s-a putut initializa");
    while (1); //  Program stops
  }


}

/*##############################################################################################*/
void loop() {
  U8 readtemp = ReadTemp();
  U8 Hyst = 2;
  char receiveVal;
//  if (Serial.available() > 0) {
//    // read the incoming byte:
//    incomingByte = Serial.read();
//
//    // say what you got:
//    Serial.print("I received: ");
//    Serial.println(incomingByte, DEC);
//  }
  if (readtemp < setPoint - Hyst)
  {
    setVoltage (0);
  }

  if ((readtemp < setPoint + Hyst) && (readtemp > setPoint - Hyst))
  {
    if ((readtemp > setPoint - Hyst) && (readtemp < setPoint))
    {
      setVoltage(0);
    }
    else
    {
      setVoltage(1);
    }
  }
  if (readtemp > setPoint + Hyst)
  {
    setVoltage(1);
  }

  //MAX TEMPERATURE-EMERGENCY STOP


  if (readtemp > 70) setVoltage(1);

  if (Serial.available() > 0)
  {
    //Serial.print(Serial.read());
    receiveVal = Serial.read();

    if (receiveVal == '1')
    {
      //Serial.print("Temperatura actuala este : ");
      Serial.println(readtemp);
    }

    if (receiveVal == '2')
    {
      //Serial.print("SetPoint-ul actual este : ");
      Serial.println(setPoint);
    }

    if (receiveVal == '3')
    {
      //Serial.print("SetPoint-ul a crescut cu un grad, iar valoarea actuala este: ");
      setPoint++;
      Serial.println(setPoint);
    }

    if (receiveVal == '4')
    {
      //Serial.print("SetPoint-ul a scazut cu un grad, iar valoarea actuala este: ");
      setPoint--;
      Serial.println(setPoint);
    }
    if (receiveVal == '5')
    {
      //Serial.print("Statusul actual al termostatulul este: ");

      if (readtemp < setPoint - Hyst)
      {
        Serial.println("Pornit");
      }

      if ((readtemp < setPoint + Hyst) && (readtemp > setPoint - Hyst))
      {
        if ((readtemp > setPoint - Hyst) && (readtemp < setPoint))

        {
          Serial.println("Pornit");
        }

        else

        {
          Serial.println("Oprit");

        }

      }
      if (readtemp > setPoint + Hyst)
      {
        Serial.println("Oprit");
      }

    }
  }
}

/*##############################################################################################
  /*##############################################################################################
*/
/*##############################################################################################

  /*##############################################################################################
  //  VERIFYING THE STATUS

  if (sdata == "Status")
  {
  Serial.print("Statusul actual al termostatulul este: ");

  if(readtemp < setPoint - Hyst)

        {
          Serial.println("Pornit");
        }

  if((readtemp < setPoint + Hyst) && (readtemp > setPoint - Hyst))
        {
            if((readtemp > setPoint - Hyst) && (readtemp < setPoint))

                       {
                         Serial.println("Pornit");
                       }

                 else

                       {
                       Serial.println("Oprit");

                       }

        }
  if(readtemp > setPoint + Hyst)
       {
            Serial.println("Oprit");
       }

  sdata.remove(0, sdata.length());

  }






*/
/*void setup() {
  pinMode(8, OUTPUT);
  Serial.begin(9600);

  }
  void loop() {
  char receiveVal;

    if(Serial.available() > 0)
    {
        receiveVal = Serial.read();

       if(receiveVal == '1')
          digitalWrite(8,HIGH);
       else if (receiveVal == '0')
          digitalWrite(8,LOW);
    }

    //digitalWrite(8, HIGH);   // turn the LED on (HIGH is the voltage level)
    //delay(1000);                       // wait for a second
    //digitalWrite(8, LOW);    // turn the LED off by making the voltage LOW
    //delay(1000);
  }
*/
