function Validar_rut(strRut)
{
    var re = /^[0-9]+-([0-9]|K)$/;
    if(re.test(strRut))
    {
        var partes = strRut.split("-");
        if(Calcula_digito_verificador(partes[0]) == partes[1])
            return true;
        else return false;
    }
    else return false;
}

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

function Calcula_digito_verificador(strRut)
{
    var returnValue = "";
    var intSum = 0;
    var intCont = 0;
    var intResto = 0;
    var intPos = 0;
    var strNum = "";
    var parametro = 0;

    intCont = 2;
    intSum = 0;
    for (intPos = strRut.length-1; intPos >= 0; intPos--)
    {
        strNum = strRut[intPos];
        intSum += parseInt(strNum) * intCont;
        if (intCont < 7)
            intCont += 1;
        else
            intCont = 2;
    }
    intResto = (intSum % 11);
    if ((11 - intResto) == 10)
        returnValue = "K";
    else
    {
        if (intResto == 0)
            returnValue = "0";
        else
            returnValue = (11 - intResto).toString();
    }
    return returnValue;
}

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

function Es_anno(value)
{
    var re = /^[1-2][0-9][0-9][0-9]$/;
    return re.test(value);
}

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

function Es_numero(value)
{
    var re = /^[0-9]+(\.[0-9]+)?$/;
    return re.test(value);
}

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

function Es_numero_entero(value)
{
    var re = /^[0-9]+$/;
    return re.test(value);
}

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

function Es_moneda(value)
{
    var re = /^[0-9]+(\.[0-9]{2})?$/;
    return re.test(value);
}

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

function Es_email(value)
{
    var exp_email1 = /(@.*@)|(\.\.)|(@\.)|(\.@)|(^\.)/;
    var exp_email2 = /^.+\@(\[?)[a-zA-Z0-9\-\.]+\.([a-zA-Z]{2,3}|[0-9]{1,3})(\]?)$/;
    return !exp_email1.test(value) && exp_email2.test(value);
}

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

function Es_fecha(date)
{
    date = date.replace(/\//g, "-");
    
    var MonthDays = Array();
    MonthDays[0] = 31;
    MonthDays[1] = 0;
    MonthDays[2] = 31;
    MonthDays[3] = 30;
    MonthDays[4] = 31;
    MonthDays[5] = 30;
    MonthDays[6] = 31;
    MonthDays[7] = 31;
    MonthDays[8] = 30;
    MonthDays[9] = 31;
    MonthDays[10] = 30;
    MonthDays[11] = 31;

    var daysInMonth;

    var aData = date.split('-');
    if (aData.length != 3)
        return false;
    
    var daySelected = parseInt(aData[0], 10);
    var monthSelected = parseInt(aData[1], 10);
    var yearSelected = parseInt(aData[2], 10);
    if (isNaN(daySelected) || isNaN(monthSelected) || isNaN(yearSelected))
        return false;

    if (monthSelected == 2)
        daysInMonth = (((yearSelected % 4 == 0) && ((!(yearSelected % 100 == 0)) || (yearSelected % 400 == 0))) ? 29 : 28 );
    else
        daysInMonth = MonthDays[monthSelected - 1];

    if (daySelected < 1 || daySelected > daysInMonth)
        return false;
    if (monthSelected < 1 || monthSelected > 12)
        return false;
    if (yearSelected < 1)
        return false;

    return true;
}

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

function Comparar_fechas(a, b)
{
    a = a.replace(/\//g, "-");
	b = b.replace(/\//g, "-");
	
	a = a.split("-");
	b = b.split("-");
    
	var a_dia = parseInt(a[0]);
	var a_mes = parseInt(a[1]);
	var a_ano = parseInt(a[2]);
	
	var b_dia = parseInt(b[0]);
	var b_mes = parseInt(b[1]);
	var b_ano = parseInt(b[2]);
	
	if(b_ano > a_ano)
	{
		return 1;
	}
	else if(b_ano < a_ano)
	{
		return -1;
	}
	else
	{
		if(b_mes > a_mes)
		{
			return 1;
		}
		else if(b_mes < a_mes)
		{
			return -1;
		}
		else
		{
			if(b_dia > a_dia)
			{
				return 1;
			}
			else if(b_dia < a_dia)
			{
				return -1;
			}
		}
	}
	return 0;
}
