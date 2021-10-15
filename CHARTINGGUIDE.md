# Charting Guide

## File Format v1 (.rch - **R**hein **CH**art)

### Layout
```
RHEIN CHART
VERSION 1

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
|Parameter|Type
|---------|-
|Type     |int
|Bpm      |float
|Offset   |int

#### Mania
|Parameter|Type
|---------|-
|Keys     |int

<br>

### **Objects**

#### Note Object
|Parameter|Type
|---------|-
|Type     |int
|Beat     |float
|Length   |float

#### Event Object
|Parameter|Type
|---------|-
|Type     |int
|Beat     |float
|Value    |any?

<br>

# Example Chart

## 4 Key Mania
```
RHEIN CHART
VERSION 1

[Properties]
Type: 0
Bpm: 170
Offset: 0
Keys: 4

[Notes]
0:0:0
1:0.25:0
2:0.5:0
3:0.75:0
0:1:0
1:1.25:0
2:1.5:0
3:1.75:0
0:2:0
1:2.25:0
2:2.5:0
3:2.75:0
0:3:0
1:3.25:0
2:3.5:0
3:3.75:0
0:4:0
1:4:0
1:4.375:0
2:4.375:0
0:4.75:0
2:4.75:0
3:4.75:0
0:5:3
1:5:3
2:5:3
3:5:3

[Events]
0:4:175
0:5:180
