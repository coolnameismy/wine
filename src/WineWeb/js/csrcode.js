var n=0;
var m=3;
function Mea(value){
    n=value;
    plays(value);
}
function plays(value){
    try
    {
        with (focus_bigpic){
                filters[0].Apply();
                for(i=0;i<m;i++)i==value?children[i].style.display="":children[i].style.display="none";
                filters[0].play();
            }
    }
    catch(e)
    {
        var d =document.getElementById("focus_bigpic").getElementsByTagName("a");
        for(i=0;i<m;i++)i==value?d[i].style.display="":d[i].style.display="none";
    }
}
function cons(value){
try
    {
        with (focus_txt){
        for(i=0;i<m;i++)i==value?children[i].className="dis":children[i].className="undis";
        }
    }
    catch(e)
    {
        var d = document.getElementById("focus_txt").getElementsByTagName("div");
        for(i=0;i<m;i++)i==value?d[i].className="dis":d[i].className="undis";
    }
}
function clearAuto(){clearInterval(autoStart)}
function setAuto(){autoStart=setInterval("auto(n)", 3000)}
function auto(){
    n++;
    if(n>=m)n=0;
    Mea(n);
}
function sub(){
    n--;
    if(n<0)n=m-1;
    Mea(n);
} //
setAuto();