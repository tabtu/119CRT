<%@ control language="C#" autoeventwireup="true" inherits="Control_S_MapSelect, App_Web_4kv54lqz" %>

<style>
    .jt{position:absolute;left:-10px;top:-10px}
</style>

<script type="text/javascript">
    //获取元素的纵坐标
    function getTop(e) {
        var offset = e.offsetTop;
        if (e.offsetParent != null) offset += getTop(e.offsetParent);
        return offset;
    }
    //获取元素的横坐标
    function getLeft(e) {
        var offset = e.offsetLeft;
        if (e.offsetParent != null) offset += getLeft(e.offsetParent);
        return offset;
    }

    function mousePosition(ev) {
        var ox = getLeft(imgPic);
        var oy = getTop(imgPic);
        if (ev.pageX || ev.pageY) {
            return { x: ev.pageX - ox, y: ev.pageY - oy };
        }
        return {
            x: ev.clientX + document.body.scrollLeft - document.body.clientLeft - ox,
            y: ev.clientY + document.body.scrollTop - document.body.clientTop - oy
        };
    }

    function mouseMove(ev) {
        ev = ev || window.event;
        var mousePos = mousePosition(ev);
        //document.getElementById('xxx').value = mousePos.x;
        //document.getElementById('yyy').value = mousePos.y;
        document.getElementById("hidden_cx").value = mousePos.x;
        document.getElementById("hidden_cy").value = mousePos.y;
    }

    document.onmousemove = mouseMove;

    function Show(el) {
        var x = parseInt(document.getElementById('hidden_cx').value) - el.offsetLeft;
        var y = parseInt(document.getElementById('hidden_cy').value) - el.offsetTop;
        //document.getElementById("localxy").innerHTML = x + ", " + y;
        document.getElementById("hidden_x").value = x;
        document.getElementById("hidden_y").value = y;

        var div1 = document.getElementById("picdot");
        div1.style.left = x + "px";
        div1.style.top = y + "px";
    }

    function setimage(url) {
        document.getElementById("imgPic").src = url;
    }

    function seticon(url) {
        document.getElementById("imgDot").src = url;
    }

    function setXY(x, y) {
        document.getElementById("hidden_x").value = x;
        document.getElementById("hidden_y").value = y;
        document.getElementById("hidden_cx").value = x;
        document.getElementById("hidden_cy").value = y;
        var div1 = document.getElementById("picdot");
        div1.style.left = x + "px";
        div1.style.top = y + "px";
    }
</script>

<body>
    <input id="hidden_cx" type="hidden" />
    <input id="hidden_cy" type="hidden" />
    <input id="hidden_x" type="hidden" name="hidden_x" />
    <input id="hidden_y" type="hidden" name="hidden_y" />
    <div style="position:relative;">
        <img id="imgPic" onclick="Show(this)" />
        <div id="picdot" style="position:absolute;left:0px;top:0px">
            <img id="imgDot" class="jt"/>
        </div>
    </div>
</body>