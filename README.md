# LondonTube

Intro
Given a list of London Tube stations and lines, write an application to answer the following question:  What stations are N stops from East Ham?  For stations with multiple routes include the station only if the minimum number of stops = N.  Print out the results in alphabetical order.
For example, if N = 5, the complete answer would be:
Bow Road
Dagenham East
East India
Hackney Wick
Leyton
Leyton Midland Road
Mile End
North Greenwich
Pudding Mill Lane
Royal Victoria
Stratford High Street
Stratford International
West Silvertown
For example, Canning Town from East Ham is possible with 4 or 5 stops, but we only consider it a valid answer for 4 stops, not 5, since we only consider the minimum number of stops.
You may use any language and tools to write your application but please use GitHub.com to store your code.
Resources
London Tube Map: https://tfl.gov.uk/cdn/static/cms/images/tube-map.gif
List of Tube stations: https://www.doogal.co.uk/london_stations.php (select "Download" then "Tube line data CSV" to download a list of stations and their lines)

code

Just run the code. The defaults of N =5 and startNode = East Ham

The algorithm is a typical recursive algorithm that traverses a graph of stations. It marks each as visited as it goes. Once it reaches the depth sent in, that is the end station.





