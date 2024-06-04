An ecommerce desktop app, providing account login, creating orders, paying balances, viewing (and filtering the view) of your purchase history.
<br>

<h1>Convention and structure:</h1>
Namespaces end with "NS" so other types can have the same name and not cause a conflict error that would occur without the NS.
<br>
<br>
Event handlers call a method to handle it asynchronously (unless it isn't something that would block the thread for a long time), and this method calls an async method which only starts a task, and this method calls the a non async method that will do the long operation. <br>
eventHandler -> methodAsync -> method
<br>
<br>
Each tab's event handlers are in their own file. The functionality of the app is separated by tabs, and namespaces reflect this. Only the file of the event handlers are excluded from the tab namespace, and that's because they're partials and therefore need the same namespace as each other. <br>
Each tab has a folder in the Tabs folder that contains the event handler file, a Functionality file with the methods the event handler file uses, and there is a file in the Queries folder with a file of queries for each tab. <br>
The Functionality classes are all named Functionality, but their file names include the tab so you can distinguish files when multiple are open at the same time. <br>
Each Functionality file has passed into its constructor a Data file that allows them to access/alter only the parts of the form that they should be able to. <br>
Naming convention:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; interface: ITabNameData <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; class: TabNameData <br>
The class is created in the event handler class of the tab so it has access to the controls of the form.<br>
The event handler passes just the data the Functionality class needs, and the Functionality class generally just passes the values to the Queries that are needed.


<h1>Database</h1>
Things to purchase in the db are separated into different tables based on the item, eg a Tea table containing all tea items or a Socks a table containing all sock items, and the user is meant to search for items (In this version, users are shown all items), and then filter the results down by selecting categories they want, for eg with socks: by Winter and Elvis Presley categories. This is rather than having an entire table of items to search through (regardless of the optimizations with indexing) to find what the user wants, or to find the item that matches the foreign key of the item in the user's purchase.
<br>
<br>
Some items will obviously not fit into any item table (although the idea is that tables will be added freely), and some will fit into multiple, but with good planning for item tables along as with the variety of the categories, the idea is that the db shouldn't be a mess or have redundant data and that if there is more space then it is balanced with the faster lookup of items.
<br>
<br>
When it comes to a purchase, a row will have an fk to an item table and another field for which table the fk references. This is done with a string version of the name of the table. It would ideally have the table name be of its own datatype that when creating the schema for a table you would specify that it is used in conjunction with the item's fk column, and that when you want to join based on item foreign keys or you want to look for certain items in the purchase table that are of a certain type, the db would know to check the table name column. Due to this current limitation, strings and if statements need to be used, but the intention is for this to be only for the current version and to rewrite those parts upon the removal of this limitation.
