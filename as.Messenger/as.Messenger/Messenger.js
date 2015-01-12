{
    var isLog = {
        framework: false,
        error: false,
        info: false,
        warning: false,
        data: false
    }
    var messengerHub = [];
    var signalUrl = '';
    var signalModel = {
        id: 0,
        message: 0,
        account: 0,
        type: 0,
        data: []
    };

}//Field

{
    $.ajax({
        url: 'Messenger/SignalServer'
    }).done(function (data) {
        signalUrl = data;
        hubStart();
    });
}//Ajax

{
    function hubStart()
    {
        $.connection.hub.url = signalUrl;
        messengerHub = $.connection.servicesHub;
        messengerHub.client.broadcastMessage = function (model) {
            Log(model);
            signalModel = model;
            setHtml(signalModel);
        };//Broadcast
        $.connection.hub.start()
            .done(function () {
                Log('connection Ok');
                signalModel.message = "ok";
                messengerHub.server.servicesSignal(signalModel);
            })
            .fail(function () {
                Log('connection Faild');
            });//Hub Start
    }//Hub Start

    function setHtml(signalModel) {
        {
            $id         = $("#MessengerPanel ul .id");
            $message    = $("#MessengerPanel ul .message");
            $account    = $("#MessengerPanel ul .account");
            $type       = $("#MessengerPanel ul .type");
            $data       = $("#MessengerPanel ul .data");
        }//Get
        {
            $id.html(signalModel.id);
            $message.html(signalModel.message);
            $account.html(signalModel.account);
            $type.html(signalModel.type);
            $data.html(signalModel.data);
        }//Set
    }//Set Html

    {
        function Log(model) {
            if (isLog.framework) if (model.type = 0) console.log(model);
            if (isLog.error) if (model.type = 1) console.log(model);
            if (isLog.info) if (model.type = 2) console.log(model);
            if (isLog.warning) if (model.type = 3) console.log(model);
            if (isLog.data) if (model.type = 4) console.log(model);
        }
    }//Log
}//Function

{
    function sendServerSignal(signalModel) {
        messengerHub.server.servicesSignal(signalModel);
    }//Server Signal

    function sendClientMessage(stringMessage) {
        signalModel.message = stringMessage;
        sendClientSignal(signalModel);
    }//client Message Signal

    function sendClientSignal(signalModel) {
        messengerHub.server.servicesSignal(signalModel);
    }//Client  Signal

    function sendServerMessage(stringMessage) {
        signalModel.message = stringMessage;
        sendServerSignal(signalModel);
    }//client Message Signal


}//Internal
