#Usings
Namespace "Views.Shared"

#Initialization
Views.Shared.Layout = ->
		
#Implementation
class Views.Shared.Layout 
	init: -> 
		$(".datepicker").datepicker(
			autoclose: true,
			todayBtn: true,
			todayHighlight: true,
			toggleActive: true,
			dateFormat: "mm/dd/yyyy",
			changeMonth: true,
			changeYear: true,
			showButtonPanel: true)
			
$ -> 
	_layout = new Views.Shared.Layout
	
	_layout.init()