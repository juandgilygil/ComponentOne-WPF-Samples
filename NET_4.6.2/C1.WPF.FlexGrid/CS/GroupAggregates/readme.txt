﻿GroupAggregates
--------------------------------------------------------------------------
Demonstrates how to display dynamic aggregates in group rows.

To show aggregates such as Sum, Count, Average etc in grid columns, all you
need to do is set the Column.GroupAggregate property to the type of 
aggregate you want to display.

If the data source is grouped and the group rows are visible, then the 
grid will calculate and display the selected aggregates automatically. If the
data changes, the aggregates are updated automatically.

For example:

<code>
	// create data source
	ICollectionView view = GetDataSource();

    // set up grouping
    view.GroupDescriptions.Add(new PropertyGroupDescription("Category"));

	// assign data source to grid
	_flex.ItemsSource = view;

	// show average product prices for each group
	_flex.Columns["Price"].GroupAggregate = Aggregate.Average;
</code>

This code will result in a grid that looks like this:

<pre>
			Product				Price
		Category 'Beverages'	 95.00 << average price for 'Beverages'
			Product 1			 80.00
			Product 2			 90.00
			Product 3			100.00
			Product 4			110.00
</pre>

If you edit the price of any product, the average will be updated automatically.