var flag=false;
var mas=new Array();
var txt='%';
var myTimer=window.setInterval('cursor();',200);
var myFlag=true;

function kolSym()
	{
	var s=txt.replace(/{}/g, "{ }");
	s=s.replace(/{/g, "");
	s=s.replace(/}/g, "");
	return s.length;
	}

function kolOtr()
	{
	s=txt.replace(/[A-Z1-7]/g, "");
	while(s.search("{}")!=-1)
		s=s.replace(/{}/g, "");
	var i=s.indexOf('%');
	var n=0;
	for(var j=i+1;j<s.length;j++)
		{
		if(s.substr(j,1)=='{')return n;
		if(s.substr(j,1)=='}')n++;
		}
	return n;
	}
function printSymbol(s,x,y)
	{
	var pos=3;
	if(s==')')
		{
		plot((x+1)*pos,(y+7)*pos);plot((x+2)*pos,(y+6)*pos);plot((x+3)*pos,(y+5)*pos);
		plot((x+3)*pos,(y+4)*pos);plot((x+3)*pos,(y+3)*pos);plot((x+2)*pos,(y+2)*pos);
		plot((x+1)*pos,(y+1)*pos);
		}
	if(s=='(')
		{
		plot((x+3)*pos,(y+7)*pos);plot((x+2)*pos,(y+6)*pos);plot((x+1)*pos,(y+5)*pos);
		plot((x+1)*pos,(y+4)*pos);plot((x+1)*pos,(y+3)*pos);plot((x+2)*pos,(y+2)*pos);
		plot((x+3)*pos,(y+1)*pos);
		}
	if(s=='9')
		{
		plot((x+2)*pos,(y+6)*pos);plot((x+2)*pos,(y+5)*pos);plot((x+2)*pos,(y+4)*pos);
		plot((x+2)*pos,(y+3)*pos);plot((x+2)*pos,(y+2)*pos);plot((x+1)*pos,(y+5)*pos);
		plot((x+3)*pos,(y+5)*pos);plot((x)*pos,(y+4)*pos);plot((x+4)*pos,(y+4)*pos);
		}
	if(s=='8')
		{
		plot((x+2)*pos,(y+6)*pos);plot((x+2)*pos,(y+5)*pos);
		plot((x+2)*pos,(y+4)*pos);plot((x+2)*pos,(y+3)*pos);plot((x+2)*pos,(y+2)*pos);
		}
	if(s=='7')
		{
		plot((x+2)*pos,(y+4)*pos);plot((x+1)*pos,(y+4)*pos);plot((x+3)*pos,(y+4)*pos);
		plot((x+2)*pos,(y+3)*pos);plot((x+2)*pos,(y+5)*pos);plot((x)*pos,(y+3)*pos);
		plot((x+1)*pos,(y+2)*pos);plot((x)*pos,(y+5)*pos);plot((x)*pos,(y+4)*pos);
		plot((x+1)*pos,(y+6)*pos);plot((x+2)*pos,(y+6)*pos);plot((x+3)*pos,(y+6)*pos);
		plot((x+4)*pos,(y+5)*pos);plot((x+4)*pos,(y+4)*pos);plot((x+4)*pos,(y+3)*pos);
		plot((x+3)*pos,(y+2)*pos);plot((x+2)*pos,(y+2)*pos);
		}
	if(s=='6')
		{
		plot((x+2)*pos,(y+4)*pos);plot((x+1)*pos,(y+3)*pos);plot((x)*pos,(y+4)*pos);
		plot((x+3)*pos,(y+5)*pos);plot((x+4)*pos,(y+4)*pos);
		}
	if(s=='5')
		{
		plot((x+2)*pos,(y+4)*pos);plot((x+3)*pos,(y+4)*pos);plot((x+4)*pos,(y+4)*pos);
		plot((x+1)*pos,(y+4)*pos);plot((x)*pos,(y+4)*pos);plot((x+3)*pos,(y+3)*pos);
		plot((x+2)*pos,(y+2)*pos);plot((x+3)*pos,(y+5)*pos);plot((x+2)*pos,(y+6)*pos);
		}
	if(s=='3')
		{
		plot((x+2)*pos,(y+3)*pos);plot((x+1)*pos,(y+5)*pos);plot((x)*pos,(y+6)*pos);
		plot((x)*pos,(y+7)*pos);plot((x+3)*pos,(y+5)*pos);plot((x+4)*pos,(y+6)*pos);
		plot((x+4)*pos,(y+7)*pos);plot((x+1)*pos,(y+4)*pos);plot((x+3)*pos,(y+4)*pos);
		}
	if(s=='4')
		{
		plot((x+2)*pos,(y+7)*pos);plot((x+1)*pos,(y+6)*pos);plot((x+3)*pos,(y+6)*pos);
		plot((x)*pos,(y+4)*pos);plot((x+4)*pos,(y+4)*pos);plot((x+1)*pos,(y+5)*pos);
		plot((x)*pos,(y+3)*pos);plot((x+4)*pos,(y+3)*pos);plot((x+3)*pos,(y+5)*pos);
		}
    if(s=='A')
    	{
        plot((x+2)*pos,(y+1)*pos);plot((x+1)*pos,(y+2)*pos);plot((x+3)*pos,(y+2)*pos);plot((x)*pos,(y+3)*pos);
        plot((x+4)*pos,(y+3)*pos);plot((x)*pos,(y+4)*pos);plot((x)*pos,(y+5)*pos);plot((x)*pos,(y+6)*pos);
        plot((x)*pos,(y+7)*pos);plot((x+4)*pos,(y+4)*pos);plot((x+4)*pos,(y+5)*pos);plot((x+4)*pos,(y+6)*pos);
        plot((x+4)*pos,(y+7)*pos);plot((x+1)*pos,(y+5)*pos);plot((x+2)*pos,(y+5)*pos);plot((x+3)*pos,(y+5)*pos);
    	}
    if(s=='B')
    	{
    	plot((x)*pos,(y+1)*pos);plot((x)*pos,(y+2)*pos);plot((x)*pos,(y+3)*pos);plot((x)*pos,(y+4)*pos);
    	plot((x)*pos,(y+5)*pos);plot((x)*pos,(y+6)*pos);plot((x)*pos,(y+7)*pos);plot((x+1)*pos,(y+1)*pos);
    	plot((x+2)*pos,(y+1)*pos);plot((x+3)*pos,(y+1)*pos);plot((x+1)*pos,(y+4)*pos);plot((x+2)*pos,(y+4)*pos);
    	plot((x+3)*pos,(y+4)*pos);plot((x+1)*pos,(y+7)*pos);plot((x+2)*pos,(y+7)*pos);plot((x+3)*pos,(y+7)*pos);
    	plot((x+4)*pos,(y+2)*pos);plot((x+4)*pos,(y+3)*pos);plot((x+4)*pos,(y+5)*pos);plot((x+4)*pos,(y+6)*pos);
    	}
    if(s=='C')
    	{
     	plot((x)*pos,(y+2)*pos);plot((x)*pos,(y+3)*pos);plot((x)*pos,(y+4)*pos);plot((x)*pos,(y+5)*pos);
     	plot((x)*pos,(y+6)*pos);plot((x+1)*pos,(y+1)*pos);plot((x+2)*pos,(y+1)*pos);plot((x+3)*pos,(y+1)*pos);
     	plot((x+1)*pos,(y+7)*pos);plot((x+2)*pos,(y+7)*pos);plot((x+3)*pos,(y+7)*pos);plot((x+4)*pos,(y+2)*pos);
     	plot((x+4)*pos,(y+6)*pos);
    	}
    if(s=='D')
    	{
    	plot((x)*pos,(y+2)*pos);plot((x)*pos,(y+3)*pos);plot((x)*pos,(y+4)*pos);plot((x)*pos,(y+5)*pos);
     	plot((x)*pos,(y+6)*pos);plot((x+1)*pos,(y+1)*pos);plot((x+2)*pos,(y+1)*pos);plot((x+3)*pos,(y+1)*pos);
     	plot((x+1)*pos,(y+7)*pos);plot((x+2)*pos,(y+7)*pos);plot((x+3)*pos,(y+7)*pos);plot((x+4)*pos,(y+2)*pos);
     	plot((x+4)*pos,(y+6)*pos);plot((x)*pos,(y+1)*pos);plot((x)*pos,(y+7)*pos);plot((x+4)*pos,(y+3)*pos);
     	plot((x+4)*pos,(y+4)*pos);plot((x+4)*pos,(y+5)*pos);
    	}
    if(s=='O')
    	{
    	plot((x)*pos,(y+2)*pos);plot((x)*pos,(y+3)*pos);plot((x)*pos,(y+4)*pos);plot((x)*pos,(y+5)*pos);
     	plot((x)*pos,(y+6)*pos);plot((x+1)*pos,(y+1)*pos);plot((x+2)*pos,(y+1)*pos);plot((x+3)*pos,(y+1)*pos);
     	plot((x+1)*pos,(y+7)*pos);plot((x+2)*pos,(y+7)*pos);plot((x+3)*pos,(y+7)*pos);plot((x+4)*pos,(y+2)*pos);
     	plot((x+4)*pos,(y+6)*pos);plot((x+4)*pos,(y+3)*pos);
     	plot((x+4)*pos,(y+4)*pos);plot((x+4)*pos,(y+5)*pos);
    	}
    if(s=='E')
    	{
    	plot((x)*pos,(y+1)*pos);plot((x)*pos,(y+2)*pos);plot((x)*pos,(y+3)*pos);plot((x)*pos,(y+4)*pos);
    	plot((x)*pos,(y+5)*pos);plot((x)*pos,(y+6)*pos);plot((x)*pos,(y+7)*pos);plot((x+1)*pos,(y+1)*pos);
    	plot((x+2)*pos,(y+1)*pos);plot((x+3)*pos,(y+1)*pos);plot((x+1)*pos,(y+4)*pos);plot((x+2)*pos,(y+4)*pos);
    	plot((x+3)*pos,(y+4)*pos);plot((x+1)*pos,(y+7)*pos);plot((x+2)*pos,(y+7)*pos);plot((x+3)*pos,(y+7)*pos);
        plot((x+4)*pos,(y+1)*pos);plot((x+4)*pos,(y+7)*pos);
    	}
    if(s=='F')
    	{
    	plot((x)*pos,(y+1)*pos);plot((x)*pos,(y+2)*pos);plot((x)*pos,(y+3)*pos);plot((x)*pos,(y+4)*pos);
    	plot((x)*pos,(y+5)*pos);plot((x)*pos,(y+6)*pos);plot((x)*pos,(y+7)*pos);plot((x+1)*pos,(y+1)*pos);
    	plot((x+2)*pos,(y+1)*pos);plot((x+3)*pos,(y+1)*pos);plot((x+1)*pos,(y+4)*pos);plot((x+2)*pos,(y+4)*pos);
    	plot((x+3)*pos,(y+4)*pos);plot((x+4)*pos,(y+1)*pos);
    	}
    if(s=='%')
    	{
    	plot((x+1)*pos,(y+7)*pos);plot((x+2)*pos,(y+7)*pos);plot((x+3)*pos,(y+7)*pos);
    	plot((x)*pos,(y+7)*pos);plot((x+4)*pos,(y+7)*pos);
    	}
    if(s=='G')
    	{
     	plot((x)*pos,(y+2)*pos);plot((x)*pos,(y+3)*pos);plot((x)*pos,(y+4)*pos);plot((x)*pos,(y+5)*pos);
     	plot((x)*pos,(y+6)*pos);plot((x+1)*pos,(y+1)*pos);plot((x+2)*pos,(y+1)*pos);plot((x+3)*pos,(y+1)*pos);
     	plot((x+1)*pos,(y+7)*pos);plot((x+2)*pos,(y+7)*pos);plot((x+3)*pos,(y+7)*pos);plot((x+4)*pos,(y+2)*pos);
     	plot((x+4)*pos,(y+6)*pos);plot((x+4)*pos,(y+5)*pos);plot((x+3)*pos,(y+5)*pos);
    	}
    if(s=='H')
    	{
    	plot((x)*pos,(y+1)*pos);plot((x)*pos,(y+2)*pos);plot((x)*pos,(y+3)*pos);plot((x)*pos,(y+4)*pos);
    	plot((x)*pos,(y+5)*pos);plot((x)*pos,(y+6)*pos);plot((x)*pos,(y+7)*pos);plot((x+4)*pos,(y+1)*pos);
    	plot((x+4)*pos,(y+2)*pos);plot((x+4)*pos,(y+3)*pos);plot((x+4)*pos,(y+4)*pos);plot((x+4)*pos,(y+5)*pos);
    	plot((x+4)*pos,(y+6)*pos);plot((x+4)*pos,(y+7)*pos);plot((x+1)*pos,(y+4)*pos);plot((x+2)*pos,(y+4)*pos);
    	plot((x+3)*pos,(y+4)*pos);
    	}
    if(s=='I')
    	{
    	plot((x)*pos,(y+1)*pos);plot((x+1)*pos,(y+1)*pos);plot((x+2)*pos,(y+1)*pos);plot((x+3)*pos,(y+1)*pos);
    	plot((x+4)*pos,(y+1)*pos);plot((x)*pos,(y+7)*pos);plot((x+1)*pos,(y+7)*pos);plot((x+2)*pos,(y+7)*pos);
    	plot((x+3)*pos,(y+7)*pos);plot((x+4)*pos,(y+7)*pos);plot((x+2)*pos,(y+2)*pos);plot((x+2)*pos,(y+3)*pos);
    	plot((x+2)*pos,(y+4)*pos);plot((x+2)*pos,(y+5)*pos);plot((x+2)*pos,(y+6)*pos);
    	}
    if(s=='J')
    	{
    	plot((x)*pos,(y+1)*pos);plot((x+1)*pos,(y+1)*pos);plot((x+2)*pos,(y+1)*pos);plot((x+3)*pos,(y+1)*pos);
    	plot((x+4)*pos,(y+1)*pos);plot((x+2)*pos,(y+2)*pos);plot((x+2)*pos,(y+3)*pos);plot((x+2)*pos,(y+4)*pos);
    	plot((x+2)*pos,(y+5)*pos);plot((x+2)*pos,(y+6)*pos);plot((x+1)*pos,(y+7)*pos);plot((x)*pos,(y+6)*pos);
    	}
    if(s=='K')
    	{
    	plot((x)*pos,(y+1)*pos);plot((x)*pos,(y+2)*pos);plot((x)*pos,(y+3)*pos);plot((x)*pos,(y+4)*pos);
    	plot((x)*pos,(y+5)*pos);plot((x)*pos,(y+6)*pos);plot((x)*pos,(y+7)*pos);plot((x+1)*pos,(y+4)*pos);
    	plot((x+2)*pos,(y+3)*pos);plot((x+3)*pos,(y+2)*pos);plot((x+4)*pos,(y+1)*pos);plot((x+2)*pos,(y+5)*pos);
    	plot((x+3)*pos,(y+6)*pos);plot((x+4)*pos,(y+7)*pos);
    	}
	if(s=='L')
		{
		plot((x)*pos,(y+1)*pos);plot((x)*pos,(y+2)*pos);plot((x)*pos,(y+3)*pos);plot((x)*pos,(y+4)*pos);
		plot((x)*pos,(y+5)*pos);plot((x)*pos,(y+6)*pos);plot((x)*pos,(y+7)*pos);
		plot((x+1)*pos,(y+7)*pos);plot((x+2)*pos,(y+7)*pos);plot((x+3)*pos,(y+7)*pos);
		plot((x+4)*pos,(y+7)*pos);plot((x+4)*pos,(y+6)*pos);
		}
	if(s=='M')
		{
		plot((x)*pos,(y+1)*pos);plot((x)*pos,(y+2)*pos);plot((x)*pos,(y+3)*pos);plot((x)*pos,(y+4)*pos);
		plot((x)*pos,(y+5)*pos);plot((x)*pos,(y+6)*pos);plot((x)*pos,(y+7)*pos);
		plot((x+4)*pos,(y+1)*pos);plot((x+4)*pos,(y+2)*pos);plot((x+4)*pos,(y+3)*pos);
		plot((x+4)*pos,(y+4)*pos);plot((x+4)*pos,(y+5)*pos);plot((x+4)*pos,(y+6)*pos);
		plot((x+4)*pos,(y+7)*pos);plot((x+1)*pos,(y+2)*pos);plot((x+3)*pos,(y+2)*pos);
		plot((x+2)*pos,(y+3)*pos);plot((x+2)*pos,(y+4)*pos);
		}
	if(s=='N')
		{
		plot((x)*pos,(y+1)*pos);plot((x)*pos,(y+2)*pos);plot((x)*pos,(y+3)*pos);plot((x)*pos,(y+4)*pos);
		plot((x)*pos,(y+5)*pos);plot((x)*pos,(y+6)*pos);plot((x)*pos,(y+7)*pos);
		plot((x+4)*pos,(y+1)*pos);plot((x+4)*pos,(y+2)*pos);plot((x+4)*pos,(y+3)*pos);
		plot((x+4)*pos,(y+4)*pos);plot((x+4)*pos,(y+5)*pos);plot((x+4)*pos,(y+6)*pos);
		plot((x+4)*pos,(y+7)*pos);plot((x+1)*pos,(y+3)*pos);plot((x+2)*pos,(y+4)*pos);
		plot((x+3)*pos,(y+5)*pos);
		}
	if(s=='P')
		{
		plot((x)*pos,(y+1)*pos);plot((x)*pos,(y+2)*pos);plot((x)*pos,(y+3)*pos);plot((x)*pos,(y+4)*pos);
		plot((x)*pos,(y+5)*pos);plot((x)*pos,(y+6)*pos);plot((x)*pos,(y+7)*pos);
		plot((x+1)*pos,(y+1)*pos);plot((x+2)*pos,(y+1)*pos);plot((x+3)*pos,(y+1)*pos);
		plot((x+1)*pos,(y+4)*pos);plot((x+2)*pos,(y+4)*pos);plot((x+3)*pos,(y+4)*pos);
		plot((x+4)*pos,(y+3)*pos);plot((x+4)*pos,(y+2)*pos);
		}
	if(s=='Q')
		{
		plot((x)*pos,(y+2)*pos);plot((x)*pos,(y+3)*pos);plot((x)*pos,(y+4)*pos);plot((x)*pos,(y+5)*pos);
		plot((x)*pos,(y+6)*pos);plot((x+1)*pos,(y+1)*pos);plot((x+2)*pos,(y+1)*pos);
		plot((x+3)*pos,(y+1)*pos);plot((x+4)*pos,(y+2)*pos);plot((x+4)*pos,(y+3)*pos);
		plot((x+4)*pos,(y+4)*pos);plot((x+4)*pos,(y+5)*pos);plot((x+1)*pos,(y+7)*pos);
		plot((x+2)*pos,(y+7)*pos);plot((x+4)*pos,(y+7)*pos);plot((x+3)*pos,(y+6)*pos);
		}
	if(s=='R')
		{
		plot((x)*pos,(y+1)*pos);plot((x)*pos,(y+2)*pos);plot((x)*pos,(y+3)*pos);plot((x)*pos,(y+4)*pos);
		plot((x)*pos,(y+5)*pos);plot((x)*pos,(y+6)*pos);plot((x)*pos,(y+7)*pos);
		plot((x+1)*pos,(y+1)*pos);plot((x+2)*pos,(y+1)*pos);plot((x+3)*pos,(y+1)*pos);
		plot((x+1)*pos,(y+4)*pos);plot((x+2)*pos,(y+4)*pos);plot((x+3)*pos,(y+4)*pos);
		plot((x+4)*pos,(y+3)*pos);plot((x+4)*pos,(y+2)*pos);plot((x+4)*pos,(y+7)*pos);
		plot((x+3)*pos,(y+6)*pos);plot((x+2)*pos,(y+5)*pos);
		}
	if(s=='S')
		{
		plot((x+1)*pos,(y+1)*pos);plot((x+2)*pos,(y+1)*pos);plot((x+3)*pos,(y+1)*pos);
		plot((x+4)*pos,(y+2)*pos);plot((x)*pos,(y+2)*pos);plot((x)*pos,(y+3)*pos);
		plot((x+1)*pos,(y+4)*pos);plot((x+2)*pos,(y+4)*pos);plot((x+3)*pos,(y+4)*pos);
		plot((x+4)*pos,(y+5)*pos);plot((x+4)*pos,(y+6)*pos);plot((x+3)*pos,(y+7)*pos);
		plot((x+2)*pos,(y+7)*pos);plot((x+1)*pos,(y+7)*pos);plot((x)*pos,(y+6)*pos);
		}
	if(s=='T')
		{
		plot((x)*pos,(y+1)*pos);plot((x+1)*pos,(y+1)*pos);plot((x+2)*pos,(y+1)*pos);
		plot((x+3)*pos,(y+1)*pos);plot((x+4)*pos,(y+1)*pos);plot((x+2)*pos,(y+2)*pos);
		plot((x+2)*pos,(y+3)*pos);plot((x+2)*pos,(y+4)*pos);plot((x+2)*pos,(y+5)*pos);
		plot((x+2)*pos,(y+6)*pos);plot((x+2)*pos,(y+7)*pos);
		}
	if(s=='U')
		{
		plot((x)*pos,(y+1)*pos);plot((x)*pos,(y+2)*pos);plot((x)*pos,(y+3)*pos);plot((x)*pos,(y+4)*pos);
		plot((x)*pos,(y+5)*pos);plot((x+4)*pos,(y+1)*pos);plot((x+4)*pos,(y+2)*pos);
		plot((x+4)*pos,(y+3)*pos);plot((x+4)*pos,(y+4)*pos);plot((x+4)*pos,(y+5)*pos);
		plot((x)*pos,(y+6)*pos);plot((x+4)*pos,(y+6)*pos);plot((x+1)*pos,(y+7)*pos);
		plot((x+2)*pos,(y+7)*pos);plot((x+3)*pos,(y+7)*pos);
		}
	if(s=='V')
		{
		plot((x)*pos,(y+1)*pos);plot((x)*pos,(y+2)*pos);plot((x)*pos,(y+3)*pos);
		plot((x)*pos,(y+4)*pos);plot((x+4)*pos,(y+1)*pos);plot((x+4)*pos,(y+2)*pos);
		plot((x+4)*pos,(y+3)*pos);plot((x+4)*pos,(y+4)*pos);plot((x)*pos,(y+5)*pos);
		plot((x+1)*pos,(y+6)*pos);plot((x+4)*pos,(y+5)*pos);plot((x+3)*pos,(y+6)*pos);
		plot((x+2)*pos,(y+7)*pos);
		}
	if(s=='W')
		{
		plot((x)*pos,(y+1)*pos);plot((x)*pos,(y+2)*pos);plot((x)*pos,(y+3)*pos);plot((x)*pos,(y+4)*pos);
		plot((x)*pos,(y+5)*pos);plot((x)*pos,(y+6)*pos);plot((x+4)*pos,(y+1)*pos);
		plot((x+4)*pos,(y+2)*pos);plot((x+4)*pos,(y+3)*pos);plot((x+4)*pos,(y+4)*pos);
		plot((x+4)*pos,(y+5)*pos);plot((x+4)*pos,(y+6)*pos);plot((x+1)*pos,(y+6)*pos);
		plot((x+1)*pos,(y+7)*pos);plot((x+2)*pos,(y+6)*pos);plot((x+2)*pos,(y+5)*pos);
		plot((x+2)*pos,(y+4)*pos);plot((x+3)*pos,(y+6)*pos);plot((x+3)*pos,(y+7)*pos);
		}
	if(s=='X')
		{
		plot((x)*pos,(y+1)*pos);plot((x)*pos,(y+2)*pos);plot((x+1)*pos,(y+3)*pos);
		plot((x+2)*pos,(y+4)*pos);plot((x+1)*pos,(y+5)*pos);plot((x)*pos,(y+6)*pos);
		plot((x)*pos,(y+7)*pos);plot((x+4)*pos,(y+1)*pos);plot((x+4)*pos,(y+2)*pos);
		plot((x+3)*pos,(y+3)*pos);plot((x+3)*pos,(y+5)*pos);plot((x+4)*pos,(y+6)*pos);
		plot((x+4)*pos,(y+7)*pos);
		}
	if(s=='Y')
		{
		plot((x)*pos,(y+1)*pos);plot((x)*pos,(y+2)*pos);plot((x+1)*pos,(y+3)*pos);
		plot((x+1)*pos,(y+4)*pos);plot((x+2)*pos,(y+5)*pos);plot((x+2)*pos,(y+6)*pos);
		plot((x+2)*pos,(y+7)*pos);plot((x+4)*pos,(y+1)*pos);plot((x+4)*pos,(y+2)*pos);
		plot((x+3)*pos,(y+3)*pos);plot((x+3)*pos,(y+4)*pos);
		}
	if(s=='Z')
		{
		plot((x)*pos,(y+1)*pos);plot((x+1)*pos,(y+1)*pos);plot((x+2)*pos,(y+1)*pos);
		plot((x+3)*pos,(y+1)*pos);plot((x+4)*pos,(y+1)*pos);plot((x)*pos,(y+7)*pos);
		plot((x+1)*pos,(y+7)*pos);plot((x+2)*pos,(y+7)*pos);plot((x+3)*pos,(y+7)*pos);
		plot((x+4)*pos,(y+7)*pos);plot((x)*pos,(y+6)*pos);plot((x+1)*pos,(y+5)*pos);
		plot((x+2)*pos,(y+4)*pos);plot((x+3)*pos,(y+3)*pos);plot((x+4)*pos,(y+2)*pos);
		}
	}

function cursor()
	{
	var s=txt;
	if(myFlag)
		{
		s=s.replace(/{}/g, "{ }");
		s=s.replace(/{/g, "");
		s=s.replace(/}/g, "");
		var i=s.indexOf('%');
		printSymbol('%',i*8+3,10);
		myFlag=false;
		}
	else
		{
		cls();
		printString(s);
		printOtr(s);
		myFlag=true;
		}
	}

function printString(s)
	{
	s=s.replace(/{}/g, "{ }");
	var x=0;
	for(var i=0;i<s.length;i++)
		{
		if(s.charAt(i)!='{' && s.charAt(i)!='}' && s.charAt(i)!='%')
			{
			printSymbol(s.charAt(i),x*8+3,10);
			x++;
			}
		if(s.charAt(i)=='%')
			x++;
		}
	}

function lineHor(x,y,l)
	{
	for(var i=0;i<l;i++)
		{
		plot(x*3,y*3);
		x++;
		}
	}

function lineHorPun(x,y,l)
	{
	for(var i=0;i<l/4;i++)
		{
		plot(x*3,y*3);
		plot((x+1)*3,y*3);
		x=x+4;
		}
	}

function lineVerPun(x,y,l)
	{
	for(var i=0;i<l/4;i++)
		{
		plot(x*3,y*3);
		plot(x*3,(y+1)*3);
		y=y+4;
		}
	}

function printOtr(s)
	{
	s=s.replace(/{}/g, "{ }");
	var k=0;
	var num=0;
	var t=0;
	var r=0;
	var flag=true;
	for(var i=0;i<s.length;i++)
		{
		if(s.substr(i,1)!='{' && s.substr(i,1)!='}')
			t++;
		if(s.substr(i,1)=='{')
			{
			num=0;
			k=0;
			r=0;
			flag=false;
			for(var j=i+1;j<s.length;j++)
				{
				if(s.substr(j,1)=='%' && k==0)
					flag=true;
				if(s.substr(j,1)!='{' && s.substr(j,1)!='}')
					r++;
				if(s.substr(j,1)=='{')
					{
					k++;
					if(k>num)num=k;
					}
				if(s.substr(j,1)=='}' && k==0)
					{
					if(flag==true)
						{
						lineHorPun(t*8+2,9-num*2,r*8-1);
						lineHorPun(t*8+2,19,r*8-1);
						lineVerPun(t*8+1,9-num*2,num*2+10);
						lineVerPun(t*8+1+r*8,9-num*2,num*2+10);
						}
					else
						{
						lineHor(t*8+2,9-num*2,r*8-1);
						}
					break;
					}
				if(s.substr(j,1)=='}' && k!=0)
					k--;
				}
			}
		}
	}

function cls()
	{
	for(var i=0;i<mas.length;i++)
		delDiv('pix'+i);
	mas.length=0;
	}

function delDiv(id)
	{
    document.getElementById('pole').removeChild(document.getElementById(id));
	}

function plot(x,y)
	{
	var d=document.createElement('div');
	d.style.width='3px';
	d.style.height='3px';
	d.style.background='#000000';
	d.style.position='absolute';
	d.style.top=y+'px';
	d.style.left=x+'px';
	d.id='pix'+mas.length;
	mas.push(d.id);
	document.getElementById('pole').appendChild(d);
	}

function presskeys(e)
	{
		if(flag==false)
		{
		var keyycode = e.keyCode?e.keyCode:e.keyChar;
		if(keyycode==13)
			return false;
		if(keyycode==48)
			{
			var i=txt.indexOf('%');
			txt=txt.substr(0,i)+')%'+txt.substr(i+1);
			cls();
			printString(txt);
			printOtr(txt);
			}
		if(keyycode==57)
			{
			var i=txt.indexOf('%');
			txt=txt.substr(0,i)+'(%'+txt.substr(i+1);
			cls();
			printString(txt);
			printOtr(txt);
			}
		if(keyycode==46)
			{
			if(txt.substr(txt.length-1,1)!='%')
				{
				var i=txt.indexOf('%');
				if(txt.substr(i+1,1)!='{' && txt.substr(i+1,1)!='}')
					{
					txt=txt.substr(0,i)+'%'+txt.substr(i+2);
					cls();
					printString(txt);
					printOtr(txt);
					return false;
					}
				if(txt.substr(i+1,1)=='{')
					{
					var n=0;
					for(var j=i+2;j<txt.length;j++)
						{
						if(txt.substr(j,1)=='}' && n==0)
							{
							txt=txt.substr(0,i)+'%'+txt.substr(j+1);
							cls();
							printString(txt);
							printOtr(txt);
							break;
							}
						if(txt.substr(j,1)=='{')n++;
						if(txt.substr(j,1)=='}' && n!=0)n--;
						}
					}
				}
			}
		if(keyycode==8)
			{
			if(txt.substr(0,1)!='%')
				{
				var i=txt.indexOf('%');
				if(txt.substr(i-1,1)!='{' && txt.substr(i-1,1)!='}')
					{
					txt=txt.substr(0,i-1)+'%'+txt.substr(i+1);
					cls();
					printString(txt);
					printOtr(txt);
					}
				if(txt.substr(i-1,1)=='}')
					{
					var n=0;
					for(var j=0;j<(i-1);j++)
						{
						if(txt.substr(i-2-j,1)=='{' && n==0)
							{
							txt=txt.substr(0,i-2-j)+'%'+txt.substr(i+1);
							cls();
							printString(txt);
							printOtr(txt);
							break;
							}
						if(txt.substr(i-2-j,1)=='}')n++;
						if(txt.substr(i-2-j,1)=='{' && n!=0)n--;
						}
					}
				}
			return false;
			}
		if(keyycode>64 && keyycode<91 && kolSym()<39)
			{
			var i=txt.indexOf('%');
			txt=txt.substr(0,i)+String.fromCharCode(keyycode)+txt.substr(i);
			cls();
			printString(txt);
			printOtr(txt);
			}
		if(keyycode==37 && txt.substr(0,1)!='%')
			{
			var i=txt.indexOf('%');
			txt=txt.substr(0,i-1)+'%'+txt.substr(i-1,1)+txt.substr(i+1);
			cls();
			printString(txt);
			printOtr(txt);
			}
		if(keyycode==39 && txt.indexOf('%')!=txt.Length-1)
			{
			var i=txt.indexOf('%');
			txt=txt.substr(0,i)+txt.substr(i+1,1)+'%'+txt.substr(i+2);
			cls();
			printString(txt);
			printOtr(txt);
			}
		document.getElementById('body').focus();
		}
	}

function addSymbol(s)
	{
	var i=txt.indexOf('%');
	if(s==2 && kolOtr()<5 && kolSym()<39)
		txt=txt.substr(0,i)+'{%}'+txt.substr(i+1);
	if(s>2 && s<10 && kolSym()<39)
		txt=txt.substr(0,i)+s+txt.substr(i);
	if(s>64 && s<91 && kolSym()<39)
		{
		var i=txt.indexOf('%');
		txt=txt.substr(0,i)+String.fromCharCode(s)+txt.substr(i);
		cls();
		printString(txt);
		printOtr(txt);
		}
	if(s==46)
		{
		if(txt.substr(txt.length-1,1)!='%')
			{
			var i=txt.indexOf('%');
			if(txt.substr(i+1,1)!='{' && txt.substr(i+1,1)!='}')
				{
				txt=txt.substr(0,i)+'%'+txt.substr(i+2);
				cls();
				printString(txt);
				printOtr(txt);
				return false;
				}
			if(txt.substr(i+1,1)=='{')
				{
				var n=0;
				for(var j=i+2;j<txt.length;j++)
					{
					if(txt.substr(j,1)=='}' && n==0)
						{
						txt=txt.substr(0,i)+'%'+txt.substr(j+1);
						cls();
						printString(txt);
						printOtr(txt);
						break;
						}
					if(txt.substr(j,1)=='{')n++;
					if(txt.substr(j,1)=='}' && n!=0)n--;
					}
				}
			}
		}
	if(s==155)
		{
		if(txt.substr(0,1)!='%')
			{
			var i=txt.indexOf('%');
			if(txt.substr(i-1,1)!='{' && txt.substr(i-1,1)!='}')
				{
				txt=txt.substr(0,i-1)+'%'+txt.substr(i+1);
				cls();
				printString(txt);
				printOtr(txt);
				}
			if(txt.substr(i-1,1)=='}')
				{
				var n=0;
				for(var j=0;j<(i-1);j++)
					{
					if(txt.substr(i-2-j,1)=='{' && n==0)
						{
						txt=txt.substr(0,i-2-j)+'%'+txt.substr(i+1);
						cls();
						printString(txt);
						printOtr(txt);
						break;
						}
					if(txt.substr(i-2-j,1)=='}')n++;
					if(txt.substr(i-2-j,1)=='{' && n!=0)n--;
					}
				}
			}
		return false;
		}
	if(s==48)
		{
		var i=txt.indexOf('%');
		txt=txt.substr(0,i)+')%'+txt.substr(i+1);
		cls();
		printString(txt);
		printOtr(txt);
		}
	if(s==57)
		{
		var i=txt.indexOf('%');
		txt=txt.substr(0,i)+'(%'+txt.substr(i+1);
		cls();
		printString(txt);
		printOtr(txt);
		}
	if(s==37 && txt.substr(0,1)!='%')
		{
		var i=txt.indexOf('%');
		txt=txt.substr(0,i-1)+'%'+txt.substr(i-1,1)+txt.substr(i+1);
		cls();
		printString(txt);
		printOtr(txt);
		}
	if(s==39 && txt.indexOf('%')!=txt.Length-1)
		{
		var i=txt.indexOf('%');
		txt=txt.substr(0,i)+txt.substr(i+1,1)+'%'+txt.substr(i+2);
		cls();
		printString(txt);
		printOtr(txt);
		}
	cls();
	printString(txt);
	printOtr(txt);
	}

function go(n){
	var s=txt.replace(/%/g, "");
	//s=s.replace(/{([A-Z1-7])}/g, "0$1");
	//s=s.replace(/{/g, "0(");
	//s=s.replace(/}/g, ")");
	s = s.replace(/\{\}/g, "");
	s = s.replace(/\(\)/g, "");

    if (parseInt(n) < 6) {

        $.ajax({
            type: 'GET',
            data: {
                'formula': s,
                'operation': n
            },

            url: 'CheckBooleanFormulaInput',

            success: function(result) {
                console.log({ o: result });
                if (n == "0" || n == "5") {

                    prompt('LaTeX', result);
                } else {

                    $('.latex_formula_image').html('<img src="data:image/jpeg;base64,' + result + '" />');
                }
            },
            error: function(xhr, message, p3) {
                alert(message);
            }
        });
    } else {
        var isByLatex = document.getElementById('byLatex').checked;;
        console.log(isByLatex);
        var depthBound = document.getElementById('depthBound').value;;
        var sizeBound = document.getElementById('sizeBound').value;;
        var countVariables = document.getElementById('countVariables').value;;

        $.ajax({
            type: 'GET',
            data: {
                'countVariables': countVariables,
                'depthBound': depthBound,
                'sizeBound': sizeBound,
                'isByLatex': isByLatex
            },

            url: 'GetRandomBooleanFormula',

            success: function (result) {
                console.log(isByLatex);

                if (isByLatex==true) {

                    prompt('LaTeX', result);
                } else {

                    $('.latex_formula_image').html('<img src="data:image/jpeg;base64,' + result + '" />');
                }
            },
            error: function (xhr, message, p3) {
                alert(message);
            }
        });
    }

	return;

}

function gogo(n)
	{
	var s=document.getElementById('textAr').value;
	if(n==0)window.open('ssv.php?dp='+s);
	if(n==1)window.open('kkv.php?dp='+s);
	}

window.onload = function()
	{
	if(get_cookie("parol")==null){
		set_cookie("parol","demo",2050,1,1);
	}
	//document.getElementById('numberParol').value=get_cookie("parol");

	printString(txt);
	printOtr(txt);
	}

function index(n)
	{
	for(i=1;i<=3;i++)
		{
		document.getElementById('tab'+i).className='nonsel';
		document.getElementById('cont'+i).style.display='none';
		}
	document.getElementById('tab'+n).className='sel';
	document.getElementById('cont'+n).style.display='block';
	if(n==1)
		{
		flag=false;
		document.getElementById('container').style.width="970px";
		document.getElementById('content').style.height="92px";
		}
	if(n==2)
		{
		flag=true;
		document.getElementById('container').style.width="856px";
		document.getElementById('content').style.height="88px";
		document.getElementById('textAr').focus();
		}
	if(n==3)
		{
		flag=false;
		document.getElementById('container').style.width="800px";
		document.getElementById('content').style.height="570px";
		}
	}

function maxLen()
	{
	var ml=document.getElementById('textAr').value.length;
	document.getElementById('numberSymbols').value=ml;
	}

/*function showhide(xx)
	{
	var oo=document.getElementById(xx)
	oo.style.display=(oo.style.display=="block")? 'none': 'block'
	}*/

function set_cookie ( name, value, exp_y, exp_m, exp_d, path, domain, secure )
{
  var cookie_string = name + "=" + escape ( value );

  if ( exp_y )
  {
    var expires = new Date ( exp_y, exp_m, exp_d );
    cookie_string += "; expires=" + expires.toGMTString();
  }

  if ( path )
        cookie_string += "; path=" + escape ( path );

  if ( domain )
        cookie_string += "; domain=" + escape ( domain );

  if ( secure )
        cookie_string += "; secure";

  document.cookie = cookie_string;
}
function get_cookie ( cookie_name )
{
  var results = document.cookie.match ( '(^|;) ?' + cookie_name + '=([^;]*)(;|$)' );

  if ( results )
    return ( unescape ( results[2] ) );
  else
    return null;
}