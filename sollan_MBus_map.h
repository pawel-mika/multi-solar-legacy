// ELPIS Sollan Modbus Slave software v1.3  data 2008-06-10
// skróty ilr = iloœæ ramek , bcst - broadcast, User Defined Exception Codes - UDEC

// LOG : historia zmian   - usuwane b³edy s¹ numerowane do identyfikacji zmian w pliku c++
// v1.0 2007-11-11 : utworzenie czyli pierwsza wersja pliku
// v1.1 2008-01-11 : poprawki ( E001 - brak liczenia SLV_MSG, E002 - brak err przy PWR_OFF, E003 praca ledów dla ext_led=1,
//                   E004 wprowadzono kopie bitów ledów podczas gdy ext_led=1,
// v1.2 2008-03-11 : optymalizacja czasów odbioru ramki
// v1.3 2008-06-10 : obs³uga autokey() samoczynna reakcja slavea na klawisze + historia naciskania

// --------------------------------------------------------------------------------------------------------------------------------------------------------
// adresy rejestrów i bitów do wpisu w polu ADRES w ramce MODBUS

// ---------------------------------------------------------------------------------------------------------------------------------------------------------
//      symbol LSBadres      // format  | opis danej                       | funkcja /    |dopuszczalny |  default  | jednostka | opis       | i po resecie|
//                           // danej   |                                  | subcode      |zakres danej |  zalecana |  [  ?  ]  | dodatkowy  | Modu³u SLAVE|
// --------------------------//---------|----------------------------------|--------------|-------------|-----------|-----------|------------|-------------|
#define MST_TIME_OUT    0x00 //  1 word | czas bez syg. MASTER do PWR_ON=0 | 0x03 i 0x06  |0-off..0xFFFF|   400     | x 12 ms   | EEautosave | z EEPROMu   |
#define LED_BLINK_TIME  0x01 //  1 word | czas wygaszenia LED-ów           | 0x03 i 0x06  | 0 .. 0xFFFF |    32     | x 12 ms   | EEautosave | z EEPROMu   |
#define LED_FLASH_TIME  0x02 //  1 word | czas b³yœniêcia LED TX i RX      | 0x03 i 0x06  | 0 .. 0xFFFF |    32     | x 12 ms   | EEautosave | z EEPROMu   |
#define ERR_TIME_OUT    0x03 //  1 word | czas mruga.ERR LED od ost. excep.| 0x03 i 0x06  | 0 .. 0xFFFF |   750     | x 12 ms   | EEautosave | z EEPROMu   |
#define FILTER_TIME     0x04 //  1 word | sta³a czas.filtru KEY i REL(mon) | 0x03 i 0x06  | 0 .. 0x00FF |   16      | x 12 ms   | EEautosave | z EEPROMu   |
#define SECURITY_CODE   0x05 //  1 word | tu zapisz 0x1234 a po ID skasuj  | 0x03 i 0x06  | 0 lub 0x1234|    0      | x 12 ms   | EEautosave | z EEPROMu   |
#define SLAVE_ID        0x06 //  1 word | do zapisu! wartoœæ bajt Hi=Lo    | 0x03 i 0x06  | 1 .. 247    |    2      |           | EEautosave | z EEPROMu   |
#define CONFIG_KEY1     0x07 //  1 word | 2 bajty pracy KEY1 w/g TABXX     | 0x03 i 0x06  | 0 .. TABXX  |           |           | EEautosave | z EEPROMu   |
#define CONFIG_KEY2     0x08 //  1 word | 2 bajty pracy KEY2 w/g TABXX     | 0x03 i 0x06  | 0 .. TABXX  |           |           | EEautosave | z EEPROMu   |
//- end blok EEPROM autosave //---------|---  !!!  MAX_AUTOSAVE_ADR !!!  --|--------------|-------------|-----------|-----------|------------|-------------|
#define EEPROM_ADR      0x09 //  1 word | adr w EEPROM do odczytu/zapisu   | 0x03 i 0x06  |MIN EE-MAX_EE|           |           |            | 0           |
#define EEPROM_DATA     0x0A //  1 word | dana do zapisu w EEPROMIE        | 0x03 i 0x06  | 0 .. 0xFFFF |           |           |            | 0           |
#define BUS_MSG_CNT     0x0B //  1 word | il. rozpoznanych ramek z CRC ok  | 0x08 / 0x0B  | 0 .. 0xFFFF |           |           |            | 0           |
#define BUS_COM_ERR     0x0C //  1 word | il. ramek z b³êdnym CRC          | 0x08 / 0x0C  | 0 .. 0xFFFF |           |           |            | 0           |
#define EXC_ERR_CNT     0x0D //  1 word | il. Exception errors+bcst errors | 0x08 / 0x0D  | 0 .. 0xFFFF |           |           |            | 0           |
#define SLV_MSG_CNT     0x0E //  1 word | il.r. z naszym ID + bcst         | 0x08 / 0x0E  | 0 .. 0xFFFF |           |           |            | 0           |
#define NO_RESP_CNT     0x0F //  1 word | il.r. bez odpowiedzi=il.bcst     | 0x08 / 0x0F  | 0 .. 0xFFFF |           |           |            | 0           |
#define NEG_ACK_CNT     0x10 //  1 word | il. ramek z odmow¹ rozkazu       | 0x08 / 0x10  | 0 .. 0xFFFF |           |           |            | 0           |
#define SLV_BUSY_CNT    0x11 //  1 word | il. odp. z Exception=06 (BUSY)   | 0x08 / 0x11  | 0 .. 0xFFFF |           |           |            | 0           |
#define BUS_CH_OVR_CNT  0x12 //  1 word | il. wyst¹pieñ b³edu OVERRUN rs-a | 0x08 / 0x12  | 0 .. 0xFFFF |           |           |            | 0           |
#define FRAME_ERR_OVR   0x13 //  1 word | il. b³êdów za d³uga ramka        | 0x03         | 0 .. 0xFFFF |           |           |            | 0           |
#define FRAME_ERR_T15   0x14 //  1 word | il. b³êdów odstêp > 1.5 znaku    | 0x03         | 0 .. 0xFFFF |           |           |            | 0           |
#define FRAME_ERR_T35   0x15 //  1 word | il. b³êdów odstêp > 3.5 znaku    | 0x03         | 0 .. 0xFFFF |           |           |            | 0           |
#define KEY_TIMER       0x16 //  1 word | czas trzymania info o klawiszach | 0x03 i 0x06  | 0 .. 0xFFFF | (0=2s)    | x 12 ms   |            | 0 (=2s)     |
#define EN_HARD_RESET   0x17 //  1 word | ustawiæ 0xF55F, reset za 20ms    | 0x03         | 0 or 0xF55F dzieœ.62815 |           |            | 0           |
//--- UWAGA! tablica moze mieæ adres max 0x17 ( 24 x word czyli 0..23 czyli 0x17 max ) ---------------------------------------------------------------------

// TABXX kodowanie w HEX reakcji przekaŸników REL1 i REL2 na wciœniêcie klawisza
//    REL1_REL2  : w zmiennej Free_Word1 Key1 Free_Word2 Key2  , xx - oznacza brak reakcji
// pierwsze wciœniêcie klawisza z tabeli wstawiamy w starszy bajt , drugie wciœniêcie w m³odszy bajt
// podanie tylko jednego bajtu ( nieistotne którego ) a drugi 0 oznacza klawisz jednofunkcyjny
#define xx_xx    0x00
#define ON_xx    0x01
#define OF_xx    0x02
#define xx_ON    0x03
#define xx_OF    0x04
#define ON_ON    0x05
#define ON_OF    0x06
#define OF_ON    0x07
#define OF_OF    0x08

// --------------------------------------------------------------------------------------------------------------|
// lp.|COILS = R/W BITS, ZEWN Msb adres Hi 0x00 czyli 16 bit 0x00** gdzie ** to adres poni¿ej, wynik 0=OFF, 1=ON |
// ---|----------------------------------------------------------------------------------------------------------|
//  1 |0x00 - REL_RD    - stan przekaŸnika RED kabel    Zapis mo¿liwy tylko gdy PWR_ON=1                         |
//  2 |0x01 - REL_YL    - stan przekaŸnika YELLOW kabel Zapis mo¿liwy tylko gdy PWR_ON=1                         |
//  3 |0x02 - PWR_ON    - =1 modu³ SLAVE ON, zasilanie modu³u zewn. wy³¹czone, REL RD i YL jako OUT, =0          |
//    |                   =0 Tylko Monitoring, zasilanie modu³u zewm. w³¹czone REL RD i YL jako READ ONLY INPUT  |
//    |----- blok chroniony bitem ext_led  - blok ten (0x03..0x08) jest pamietany nawet po zmianie ext_led       |
//  4 |0x03 - LED_RXD   - stan ON/OFF diody Led RX ( odbiór )                                                    |
//  5 |0x04 - LED_TXD   - stan ON/OFF diody Led TX ( transmisja )                                                |
//  6 |0x05 - LED_ERR   - stan ON/OFF diody Led ERROR po RST =0 czyli OFF                                        |
//  7 |0x06 - BLINK_RXD - stan Blink ( mruganie) ON/OFF diody Led RX (odbiór), po RST=0 czyli OFF                |
//  8 |0x07 - BLINK_TXD - stan Blink ( mruganie) ON/OFF diody Led TX (transmisja), po RST=0 czyli OFF            |
//  9 |0x08 - BLINK_ERR - stan Blink ( mruganie) ON/OFF diody Led ERROR, po RST=0 czyli OFF                      |
//    |----- blok end                                                                                            |
// 10 |0x09 - EXT_LED   - Ledy s¹ sterowalne z zewn¹trz tylko dla EXT_LED=1 , ale po RST =0 czyli OFF,           |
//    |                   mozna je wykorzystaæ do identyfikacji tego jednego wœród wielu sterowników w sieci     |
//    |                   Czas ext_led=1 nieograniczony ( pilnowaæ tego ) chyba ze RST lub patrz ni¿ej
//    |                   Funkcja MST_TIME_OUT>0 spowoduje skasowanie ext_led po tym czasie                      |
// -----------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------------------------|
// BIT INPUTS READ ONLY, ZEWN Msb adresu Hi 0x10 czyli 16 bit 0x10** gdzie ** to adres poni¿ej, wynik 0=OFF, 1=ON    |
// ------------------------------------------------------------------------------------------------------------------|
// 0x00 - KEY_1     - stan klawisza 1 (1= wciœniêty )                                                                |
// 0x01 - KEY_2     - stan klawisza 2 (1= wciœniêty )                                                                |
// 0x02 - EE_DONE   - 1-zapis do EEPROM zakoñczony, stan funkcji EEPROM Autosave i wpisu do EEPROM,ten bit po RST=1  |
// ------------------------------------------------------------------------------------------------------------------|

// odwo³ania do funcji z wartoœciami innymi ni¿ z zakresów poni¿ej generuja odp. ERROR tzw. exception w/g tabeli na dole

// defienicje zakresu funkcji dostêpnych w protokole
#define MAX_FUN    6 // dostêpne funkcje sterownika 01,02,03,04,05,06
// maping funkcji 01_Read i 05 Write physical coils or internal bits
// UWAGA fun 05 Write dozwolone s¹ tylko dwie wartoœci word 0x0000 clr bit=0 i 0xFF00 dla set bit=1
#define F1_OFS  0x00 //  pierwszy bit jest pod adresem F1_OFS wœród tabeli bitów READ & WRITE
#define F1_MAX    10 //  ca³kowita MAX iloœæ bitów w tym bloku, reszta w dope³nieniu do 8bitów zawsze 0

// maping funkcji 02 Read Physical Discrete inputs - bity READ ONLY
#define F2_OFS  0x00 // pierwszy bit jest pod adresem F2_OFS wœród tabeli bitów READ ONLY
#define F2_MAX     3 // ca³kowita MAX iloœæ bitów w tym bloku, reszta w dope³nieniu do 8bitów zawsze 0

// maping funkcji 03 Read i 06 Write : Holding Registers 16 bit
#define F3_OFS  0x00 //  tablica par[] start adres bloku
#define F3_MAX    24 //  tablica par[] zawiera tyle elementów

// maping funkcji 04 Read Input Registers
#define F4_OFS  0x00 //  tablica par[] start adres bloku
#define F4_MAX    24 //  tablica par[] zawiera tyle elementów

// UWAGA !!!! przy zmianie g³ównej mapy pamiêci EEPROM_ADR zawsze ma byæ na koñcu bloku danych EE_AUTOSAVE
#define MAX_AUTOSAVE    EEPROM_ADR // iloœæ danych typu word w tablicy par[] z autosave, realnie w EE adr [0.. MAX_AUTOSAVE x 2 ]
#define MAX_EE_ADR      0x7E // dana word po³ozenie bajt HI adr 0x7E , bajt LO adr 0x7F
#define MIN_EE_ADR      MAX_AUTOSAVE  // bo resztê ponizej zajmuje blok autosave

// odpowiedzi sterownika i tzw. "exception codes" - zwracane kody b³edów
#define BAD_FUN  0x01  // funkcja MODBUS o tym numerze w tym sterwoniku jest nieobs³ugiwana
#define BAD_ADR  0x02  // funkcja w polu adres zawiera z³y lub niedozwolony adres
#define BAD_VAL  0x03  // wartoœæ w polu iloœæ lub dana jest poza zakresem dla tej funkcji
#define SLV_ERR  0x04  // inny b³¹d
#define SLV_ACK  0x05  // potwierdzenie wykonania lub rozpoczêcia
#define SLV_BUSY 0x06  // przetwarzam , prosze czekaæ (np. przy zapisie do EEprom na czas 20ms )
#define SLV_NACK 0x07  // odmowa wykonania rozkazu ( np.Protection Write Active , sprawdziæ bity i bajty chroni¹ce przed zapisem)

// INFORMACJE DODATKOWE

// [ programowanie ID ]
// w SECURITY_CODE wpisz 0x1234 kod potrzebny do odblokowania zapisu SLAVE_ID, po udanym zapisie skasowaæ na 0
// UWAGA !!! ID zakres ( 1..247_) czyli dolny bajt ale w obu bajtach wysy³amy to samo ID
// np. ID=15;  wysy³amy wysy³amy zapis do SECURITY_CODE=0x1234, a potem zapis do SLAVE_ID 0x0F0F; potwierdzenie to odczyt SECURITY_CODE=0

// pamiêc EEPROM ma 128 bajtów 0..0x7F po dwa bajty na dan¹ word czyli 0x00,0x01  .. 0x7E,0x7F , maks. iloœæ zapisów
// po poprawnym zapisie ( sprawdzamy bit EE_DONE ) skasowaæ SECURITY_CODE na 0

// [ zmienne FREE_WORD ] s¹ do dowolnego wykorzystania przez program z PC
// czas odpowiedzi - zwykle sterownik SLAVE odpowiada po od 4..5 ms na transmisjê

// dioda ERR
// led OFF - No errors, led constant ON - PWR OFF - tryb monitoring
// BLINK- in last ERR_TIME_OUT[s] was "exception" with our ID or broadcast
// Uwaga odczyt STANU LEDów w module ModbusPluginMainForm jest prawdziwy jedynie dla trybu ExtLED=1, dla 0 podawane s¹ dane chwilowe (blink)
// [ Filter TIME ] czas potrzebny aby sygna³ z zewnatrz potraktowano jako stabilny i ustawiono np. KEY1 = 1 , poprawnie wygenerowany klawisz

// reset modu³u wyslij do rej 40024  ( 24 -> 0..23) wartoœæ 0xF55F lub dziesiêtnie 62815 i tyle

/*

 Struktura programu :
 START :
 setup_MBus();
 main() - switch for task 12ms
  - task 0 : display_leds()
  - task 1 : inputscan()
  - task 2 : o_fet=!pwr_on; auto_key();
  - task 3 : hard_reset_detector()
  - task 4 : EE_agent()
  - task 5 : detect_master()
 -----------------------------
 isr()
   - TMR2IF WatchDog + set next task on
   - TMR1IF lub RCIF ( odbierz znak jednoczeœnie kontroluj czas )
      - calc_CRC()
      - frame_check()
          - adressing_check()
          - protection_write_check()
          - exception ?
            TAK - mb_excep_rsp_pdu()
                   - our_CRC()
                   - writeRS()
            NIE - broadcast ?
                   NIE : mb_rsp_pdu()
                           - our_CRC()
                           - writeRS()
                   TAK : mb_broadcast() // nie napisane
*/

/* zmiany do wprowadzenia w modbus plugin,
- ukryæ mozliwoœæ wysy³ania Relay 0 i Relay 1 gdy power=False
- ukryæ mozliwoœæ wysy³ania na LEDY cokolwiek jesli Ext led control=False
- dodac Rescan Slave ( by nie klikaæ w numerek na liœcie )
- dodaæ jednostki do kazdego pola i pokazaæ po przeliczeniu ile to jest np blink time =50 x 12ms = 600 ms itd
- nieprawid³owo security code ukryæ wartoœæ , zrobiæ checkbox który wysle do slave 0x1234 ( przy odczycie pokazaæ jedynie stan check box .. )
- numer slave wymaga podania go w formacie np. 3 to 0x0303 np. 15 to 0x0F0F zrobiæ tak aby samo siê podstawia³o i dekodowa³o jedynie 1 bajt przy odczycie
  obecnie trzeba wpisaæ ... np dla 3 ... 303 ( 0303 ) co jest nie zrozumia³e dla nikogo ( to jedynie zabezpieczenie )
- zrobiæ check box ( opcja aktywna lub nie ) zablokowaæ mo¿liwoœæ podania numeru pod³¹czonego ju¿ i aktywnego w sieci slavea
- po zmianie numeru wymusiæ na obs³ugujacym skasowanie security code na 0
- zrobiæ check box - czy ograniczyæ liczbê slave do 31 ( obecnie tak póŸniej damy silniejsze scalaki )
- oczywiœcie zrobiæ to ustalone sk³¹danie z tabeli TABXX w Key config 1 i 2  pamietaj¹c ¿e pokazywaæ trzeba HEX a nie jak obecnie dziesiêtnie bo nie widaæ
wciœniêciu
                        ConfigK1                          ConfigK2
 Wciœniêcia:    Pierwsze          Drugie           Pierwsze        Drugie   
              Przek1 Przek2    Przek1 Przek2    Przek1 Przek2     Przek1 Przek2  
              xx    _  xx       xx  _  xx         xx  _  xx         xx  _ xx            
                   ...
              OFF _  OFF         OFF _ OFF         OFF _  OFF         OFF _ OFF       
                      
                   Zapisz ConfigK1                          Zapisz ConfigK2
                                                
                             Odczytaj/ odœwie¿  stan bie¿¹cy
tak jak widaæ na ekranie sk³adamy free_word 1 dla ConfigK1 po lewej starszy bajt po prawej  m³odszy
w ka¿dej kolumnie mozna zaznaczyæ tylko jeden checkbox
kolumny s¹ cztery a w ka¿dej tabela TABXX ( patrz wyzej )
*/

