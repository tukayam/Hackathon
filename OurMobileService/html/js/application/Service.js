// Crappy baseline code
var client = new WindowsAzure.MobileServiceClient(
    "https://hackathontry.azure-mobile.net/",
    "QIBDpJVCkYEFBENJOEoRSVrwnZuFdE12");

// Get users
var userList = [];
function getUsers()
{
    var users = client.getTable('user');
    users.read().done(function (results) {
        var users = JSON.stringify(results);
        renderUsers(users);

    }, function (err) {
        alert("Error: " + err);
    });
    
}
function renderUsers(userList)
{
    var container = $("#users")
    container.empty();
    for(var i=0;i<userList.length;i++)
    {
        var user=userList[i];
        container.append("<a href='#' onclick='showUserData(" + user.Identifier + "'>" + user.Name + "</a><br>");
    }
}

function getOrders(userID)
{
    var orders = client.getTable('order');
    orders.where({
        userId:  userID 
    }).read().done(function (results) {
        var orders = JSON.stringify(results);
        renderOrders(orders);

    }, function (err) {
        alert("Error: " + err);
    });
}

function renderOrders(orders)
{
    var container = $("#users")
    container.empty();
    for (var i = 0; i < orders.length; i++) {
        var order = userList[i];
        var items = order.Items;
        container.append("<div><h2>" + order.DateTime + "</h2></div>");
        container.append("<table>" );
        for (var o = 0; o < items.length; o++)
        {
            var item = items[o];
            container.append("<tr><td>" + item.Name + "</td><td>" + item.Amount + "</td><td>" + "</td><td>" + item.Price + "</td>");
        }
        container.append("</table>");
        
    }
}
