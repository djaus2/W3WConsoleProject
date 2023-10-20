# W3W

## About
A C# .Net 6 Console app that can generate W3W map tri-word and related json data from GPS coordinates.

- W3W: What Three Words
- Three words uniquley define a square 3mx3m (10'x10') world-wide
- eg Try this: https://what3words.com/adjust.case.trains

## Links
- [Getting Started](https://developer.what3words.com/public-api)
- [Get API Key](https://what3words.com/select-plan?referrer=/public-api)

## Sample Output

```
Hi from Word3Word App!
Getting json string using httpClient.GetAsync
=====================================================
json string: {"country":"AU","square":{"southwest":{"lng":144.918576,"lat":-37.751105},"northeast":{"lng":144.91861,"lat":-37.751078}},"nearestPlace":"Essendon, Victoria","coordinates":{"lng":144.918593,"lat":-37.751092},"words":"adjust.case.trains","language":"en","map":"https:\/\/w3w.co\/adjust.case.trains"}
---------------------------
json string parsed OK

Getting json direct using httpClient.GetFromJsonAsync
=====================================================
Country: AU
Nearest Place: Essendon, Victoria
W3W Words: adjust.case.trains
---------------------------
Map Link: https://w3w.co/adjust.case.trains
The map link URL is on the clipboard.
```

## Usage
Get What3Words Tri-words for GPS location.
- Get an API Key _(See link above)_
- Insert into Data.cs
  - Insert lattitude and longitude coordinates into Data.cs  
OR
- Enter lattitude longitude on command line.
  - AND (Optionally) enter API Key as third parameter.
- Run the app.
- Paste the Url generated into a Web Browser.


