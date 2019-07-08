
var entityMenu = (function ()
{
    var entityContainer = '';
    var applicationContainer = '';
    var applicationUrl = '';
    var selectedEntityId = '';
    var selectedEntityObjectId = '';

    var init = function (config)
    {
        entityMenu.entityContainer = config.entityContainer;
        entityMenu.applicationContainer = config.applicationContainer;
        entityMenu.applicationUrl = config.applicationUrl;
        entityMenu.selectedEntityId = config.selectedEntityId;
        entityMenu.selectedEntityObjectId = config.selectedEntityObjectId;

        if (config.selectedEntityId && config.selectedEntityObjectId)
        {

            $.when(entityMenu.selectEntity()).done(function (a1)
            {
                entityMenu.selectSubEntity();
            });

        }

        bindFunctions();

    };


    var bindFunctions = function ()
    {
        $(".entityItem").on("click", function ()
        {
            var sender = $(this);
            selectEntity(sender,true);
        });
        $("#entityObjectsListContainer").on("click", ".entityObjectItem",
            function ()
            {
                var sender = $(this);
                selectSubEntity(sender,true);
            }

            );

        $("#applicationsListContainer").on("click", '#searchApplications', searchApplications);
    }

    var selectEntity = function (sender,fromInput)
    {
        var selectedItem = null;


        if (entityMenu.selectedEntityId && !fromInput)
        {
            selectedItem = $('.entityItem[data-entityId=' + entityMenu.selectedEntityId + ']');


        }
        else
        {
            //get selected item by entityId

            var selectedItem = sender;

        }

        if (selectEntity)
        {
            selectedItem.addClass("list-item-selected");

            clearSelection(selectedItem);

            var selectedEntityId = selectedItem.attr("data-entityId");

            startLoadingPanel();



            return $.ajax({
                contentType: 'application/json; charset=utf-8',
                type: 'POST',
                url: '/Entities/GetEntitiesObjects',
                data: JSON.stringify({ 'entityId': selectedEntityId })
            }).done(function (partialViewResult)
            {

                entityMenu.applicationContainer.addClass('hidden');
                $("#entityObjectsListContainer").html(partialViewResult);

                stopLoadingPanel();

            });
        }


    };




    var selectSubEntity = function (sender,fromInput)
    {
        var selectedEntityObject = null;

        if (entityMenu.selectedEntityObjectId && !fromInput)
        {
            selectedEntityObject = $('.entityObjectItem[data-entityobjectid=' + entityMenu.selectedEntityObjectId + ']');


        }
        else
        {
            //get selected item by entityId

            var selectedEntityObject = sender;

        }

        if (selectedEntityObject)
        {

            selectedEntityObject.addClass("list-item-selected");

            clearSelection(selectedEntityObject);

            selectedEntityObjectId = selectedEntityObject.attr("data-entityobjectId");

            //refresh the panel
            getApplicationsForEntityObject(selectedEntityObjectId, 1000, '');
        }

    };

    var searchApplications = function (filter)
    {
        filter = $("#filter").val();
        getApplicationsForEntityObject(selectedEntityObjectId, 1000, filter);
    };


    var getApplicationsForEntityObject = function (entityObjectId, pageSize, filter)
    {
        startLoadingPanel();

        $.ajax({
            contentType: 'application/json; charset=utf-8',
            type: 'POST',
            url: entityMenu.applicationUrl,
            data: JSON.stringify({ 'entityobjectId': entityObjectId, 'currentFilter': filter, 'pageSize': pageSize })
        }).done(function (partialViewResult)
        {
            entityMenu.applicationContainer.html(partialViewResult);
            entityMenu.applicationContainer.removeClass("hidden");

            stopLoadingPanel();
        });
    };

    //UTILS

    var clearSelection = function (item)
    {
        item.siblings().removeClass("list-item-selected");
    };

    return {
        init: init,
        selectEntity: selectEntity,
        selectSubEntity: selectSubEntity
    };

})();


