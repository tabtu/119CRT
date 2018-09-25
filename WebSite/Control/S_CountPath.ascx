<%@ Control Language="C#" AutoEventWireup="true" CodeFile="S_CountPath.ascx.cs" Inherits="Control_S_CountPath" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
	<style type="text/css">
		#allmap1 {width: 800px;height: 400px;overflow: hidden;margin:0;font-family:"微软雅黑";}
        #allmap2 {width: 800px;height: 400px;overflow: hidden;margin:0;font-family:"微软雅黑";}
	</style>
	<script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=cL6WkBLcRxcyBvS1ShW8HYh8"></script>
	<title>计算路径</title>
</head>
<body>
    <label id="label_gps"></label>
    <input id="hidden_lng" type="hidden" name="hidden_lng" />
    <input id="hidden_lat" type="hidden" name="hidden_lat" />

    <table>
        <tr>
            <td><div id="map1_container"><div id="allmap1"></div></div></td>
            <td><div id="r-result1"></div></td>
        </tr>
        <tr>
            <td><div id="map2_container"><div id="allmap2"></div></div></td>
            <td><div id="r-result2"></div></td>
        </tr>
    </table>
</body>
</html>
<script type="text/javascript">
    var s1_lng = "<%=Get_s1_Lng()%>";
    var s1_lat = "<%=Get_s1_Lat()%>";
    var s2_lng = "<%=Get_s2_Lng()%>";
    var s2_lat = "<%=Get_s2_Lat()%>";
    var e_lng = "<%=Get_e_Lng()%>";
    var e_lat = "<%=Get_e_Lat()%>";

    var p1 = new BMap.Point(s1_lng, s1_lat);
    var p2 = new BMap.Point(s2_lng, s2_lat);
    var p0 = new BMap.Point(e_lng, e_lat);

    var map1 = new BMap.Map("allmap1");
    var driving = new BMap.DrivingRoute(map1, { renderOptions: { map: map1, panel: "r-result1", autoViewport: true } });
    driving.search(p1, p0);
    map1.disableDoubleClickZoom();
    map1.enableScrollWheelZoom();

    var map2 = new BMap.Map("allmap2");
    var driving = new BMap.DrivingRoute(map2, { renderOptions: { map: map2, panel: "r-result2", autoViewport: true } });
    driving.search(p2, p0);
    map2.disableDoubleClickZoom();
    map2.enableScrollWheelZoom();
</script>