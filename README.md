Namespaces end with "NS" so other types can have the same name and not cause a conflict error that would occur without the NS.
<br>
<br>
Event handlers call a method to handle it asynchronously (unless it isn't something that would block the thread for a long time), and this method calls an async method which only starts a task, and this method calls the a non async method that will do the long operation. <br>
eventHandler -> methodAsync -> method
<br>
<br>
Each tab's event handlers are in their own file. The functionality of the app is separated by tabs, and namespaces reflect this. Only the file of the event handlers are excluded from the tab namespace, and that's because they're partials and therefore need the same namespace as each other. <br>
Each tab has a folder in the Tabs folder that contains the event handler file, a Functionality file with the methods the event handler file uses, and there is a file in the Queries folder with a file of queries for each tab. <br>
The Functionality classes are all named functionality, but their file naes include the tab so you can distinguish files when multiple are open at the same time. <br>
Each Functionality file has passed into its constructor a Data file that allows them to access/alter only the parts of the form that they should be able to. <br>
Naming convention:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; interface: ITabNameData <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; class: TabNameData <br>
The class is created in the event handler class of the tab so it has access to the controls of the form.<br>
The event handler passes just the data the Functionality class needs, and the Functionality class generally just passes the values to the Queries that are needed.
