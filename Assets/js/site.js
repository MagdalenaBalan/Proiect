//component initializations



//init tooltiop
$('[data-toggle="tooltip"]').tooltip();


//innit left panel
$(document).on('click', '.cd-panel', function (e)
{
    if ($(e.target).is('.cd-panel') || $(e.target).is('.cd-panel-close'))
    {
        $('.cd-panel').removeClass('is-visible');
        e.preventDefault();
    }
});

var startLoadingPanel = function ()
{
    $("#content-panel").loading({
        message: 'Processing ...'
    });
};

var stopLoadingPanel = function ()
{
    $("#content-panel").loading('stop');
};

var pageSize = 100;