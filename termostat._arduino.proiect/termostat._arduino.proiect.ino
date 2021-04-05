 #include <SFE_BMP180.h> 
 #include <Wire.h> 
 #define ledPin 6 
 SFE_BMP180 tmp; 
 String sdata = ""; 
 typedef unsigned char U8; 
 U8 setPoint = 18; 
 
 // Detectnig the temperature function  
 
 U8 ReadTemp() 
               { 
                U8 status; 
                double T; 
                status = tmp.startTemperature(); 

                if(status != 0) 
                      {  
                        delay(status); //waiting for measurement to be completed; 
                        //measurement saved in T 
                        status = tmp.getTemperature(T); 
                        if(status != 0) 
                              { 
                                return T;
                              }
                        
                       }
               } 

//  switching On/Off the light using boolean var 
void setVoltage(bool state) 
                          { 
                             digitalWrite(ledPin, state); 
                             //inverted values - setVoltage(0) = 1, setVoltage(1) = 0;
                          }
void setup() {
    pinMode(ledPin, OUTPUT); 
    Serial.begin(9600); 
    Serial.println("REBOOT"); 

    //SENSOR INITIALIZATION 
    if(tmp.begin()) 
            { 
              Serial.println("Senzorul BMP180 este initializat cu succes"); 
            } 
            else 
            { 
              Serial.println("Senzorul BMP180 nu s-a putut initializa cu succes"); 
              while (1);//program stops
            }

}

void loop() { 
  U8 readtemp = ReadTemp(); 
  U8 Hyst = 2;  
  char receiveVal; 
      if(readtemp < setPoint - Hyst) 
                 { 
                   setVoltage (0); 
                 } 

      if((readtemp < setPoint + Hyst) && (readtemp > setPoint - Hyst)) 
                 {   
                   if((readtemp > setPoint - Hyst) && (readtemp < setPoint))  
                              {  
                                setVoltage(0);  
                              } 
                        else  
                              {  
                                setVoltage(1); 
                              }
                               
                  } 
      
      if(readtemp > setPoint + Hyst) 
                  {  
                    setVoltage(1);
                  }   

//Maximum temperature- emergency stop; 
if(readtemp > 70) setVoltage(1); 

    receiveVal = Serial.read();
                 if(receiveVal == 1)
                 {
                   Serial.print("Temperatura actuala este : ");     
                    Serial.println(readtemp); 
                 }
                   if(receiveVal == 2)
                 {  
                   Serial.print("SetPoint-ul actual este : ");     
                    Serial.println(setPoint);   
                 }

                 if(receiveVal == 3) 
                 {
                   Serial.print("SetPoint-ul a crescut cu un grad, iar valoarea actuala este: ");
                    setPoint++;
                    Serial.println(setPoint);
                 }

                 if(receiveVal == 4)
                 {
                   Serial.print("SetPoint-ul a scazut cu un grad, iar valoarea actuala este: ");
                    setPoint--;
                    Serial.println(setPoint);  
                 }
             
                if(receiveVal == 5) 
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
              
               } 
                 
  
  

}
