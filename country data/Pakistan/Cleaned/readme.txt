Pakistan data files

Doc1.kml - State Boundaries
Doc2.kml - District Boundaries
Doc3.kml - Tesil Boundaries

Files from Humanitarian data exchange,  extracted from KMZ distribution.
Files from Pakistan Census Office

Document files have CDATA Fields 
The first CDATA field is the name of the data field - suggest that this is manually editted to replace as a text string

The other CDATA fields are HTML Tables with admin data
First remove the CDATA Fields.   There appear to be a couple of Meta lines which can be removed
Remove some of the KML elements: "Snippet", "color", "extrude", "Style", "altitudeMode", "head", "styleUrl"

Convert the Administrative data to KML.  The admin data was included in the CDATA field, and was originally an HTML Table.

Export the administrative data in a seven column table,  region name,  followed by names and codes of up to three levels.   
Export format as Comma Separated Values

