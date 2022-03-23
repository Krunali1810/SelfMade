﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VegaLite-EXP.aspx.cs" Inherits="Vega_Lite.VegaLite_EXP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <script src="https://cdn.jsdelivr.net/npm/vega@5.21.0"></script>
    <script src="https://cdn.jsdelivr.net/npm/vega-lite@5.1.1"></script>
    <script src="https://cdn.jsdelivr.net/npm/vega-embed@6.20.0"></script>
</head>
<body>
    <div id="vis" />
    <script>
        const spec =
        {
            "$schema": "https://vega.github.io/schema/vega-lite/v5.json",
            "description": "A bar graph showing the scores of the top 5 students. This shows an example of the window transform, for how the top K (5) can be filtered, and also how a rank can be computed for each student.",
            "data": {
                "values": [
                    { "student": "A", "score": 100 },
                    { "student": "B", "score": 56 },
                    { "student": "C", "score": 88 },
                    { "student": "D", "score": 65 },
                    { "student": "E", "score": 45 },
                    { "student": "F", "score": 23 },
                    { "student": "G", "score": 66 },
                    { "student": "H", "score": 67 },
                    { "student": "I", "score": 13 },
                    { "student": "J", "score": 12 },
                    { "student": "K", "score": 50 },
                    { "student": "L", "score": 78 },
                    { "student": "M", "score": 66 },
                    { "student": "N", "score": 30 },
                    { "student": "O", "score": 97 },
                    { "student": "P", "score": 75 },
                    { "student": "Q", "score": 24 },
                    { "student": "R", "score": 42 },
                    { "student": "S", "score": 76 },
                    { "student": "T", "score": 78 },
                    { "student": "U", "score": 21 },
                    { "student": "V", "score": 46 }
                ]
            },
            "transform": [
                {
                    "window": [{ "op": "rank", "as": "rank" }],
                    "sort": [{ "field": "score", "order": "descending" }]
                },
                { "filter": "datum.rank <= 5" }
            ],
            "mark": "bar",
            "encoding": {
                "x": { "field": "score", "type": "quantitative" },
                "y": {
                    "field": "student",
                    "type": "nominal",
                    "sort": { "field": "score", "op": "average", "order": "descending" }
                }
            },
            "config": {}
        };
        vegaEmbed("#vis", spec, { mode: "vega-lite" }).then(console.log).catch(console.warn);
  </script>
</body>
</html>
