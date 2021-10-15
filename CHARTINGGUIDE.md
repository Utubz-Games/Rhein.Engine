# Charting Guide

## File Format v1 (.rch - **R**hein **CH**art)
? = Optional

### Layout
```
RHEIN CHART VERSION 1

[Properties]
Type: 0
SomeValue: 0

[Notes]
0:0:0

[Events]
0:16:125
```

<br>

### **Properties**

#### General
|Parameter|Type     |Default
|---------|---------|-
|Type     |int      |N/A
|Bpm      |float    |N/A
|Offset   |float    |N/A

#### Mania
|Parameter|Type     |Default
|---------|---------|-
|Keys     |int      |N/A

<br>

### **Objects**

#### Note Object
|Parameter|Type     |Default
|---------|---------|-
|Type     |int      |N/A
|Beat     |float    |N/A
|Length   |float?   |0.0

#### Event Object
|Parameter|Type     |Default
|---------|---------|-
|Type     |int      |N/A
|Beat     |float    |N/A
|Value    |any?     |null

<br>

# Example Chart

## 4 Key Mania
```
RHEIN CHART VERSION 1

[Properties]
Type: 0
Bpm: 170
Offset: 0
Keys: 4

[Notes]
0:0
1:0.25
2:0.5
3:0.75
0:1
1:1.25
2:1.5
3:1.75
0:2
1:2.25
2:2.5
3:2.75
0:3
1:3.25
2:3.5
3:3.75
0:4
1:4
1:4.375
2:4.375
0:4.75
2:4.75
3:4.75
0:5
1:5
2:5
3:5

[Events]
0:4:175
0:5:180
