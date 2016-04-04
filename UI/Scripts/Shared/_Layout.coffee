#Usings
Namespace "Views.Shared"

#Initialization
Views.Shared.Layout = ->
		
#Implementation
class Views.Shared.Layout 
	init: -> 
		$(".datepicker").datepicker
		    dateformat: "MM/dd/yy"
		    			
$ -> 
	_layout = new Views.Shared.Layout
	
	_layout.init()