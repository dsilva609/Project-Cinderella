#Usings
Namespace "Views.Shared"

#Initialization
Views.Shared.Layout = ->
		
#Implementation
class Views.Shared.Layout 
	init: -> 
		$(".datepicker").datepicker()
		
		$(".datepicker-year").datepicker
			dateFormat: "yy",
			changeYear: true,
			changeMonth: false,
			showButtonPanel: true
						
$ -> 
	_layout = new Views.Shared.Layout
	
	_layout.init()