﻿#Usings
Namespace "Views.Shared"

#Initialization
Views.Shared.Layout = ->
		
#Implementation
class Views.Shared.Layout 

	deleteItem = (item) -> 
		ID = $(item).data "id"
		
		bootbox.dialog 
			message: "Are you sure you want to delete this item?",
			buttons: 
				cancel: 
					label: "No"
				confirm: 
					label: "Yes"
					className: "btn-danger"
					callback: ->
						window.location.href = deleteUrl + "/" + ID
		return false
	
	init: -> 
		$(".datepicker").datepicker
			autoclose: true,
			todayBtn: true,
			todayHighlight: true,
			toggleActive: true,
			dateFormat: "mm/dd/yyyy",
			changeMonth: true,
			changeYear: true,
			showButtonPanel: true
		
		$('[class~=deleteBtn]').on "click", ->
			deleteItem($(this))

			return false
					
		$('.panel-collapse').on "click", ->
			$(this).find("span").toggleClass( "fa-chevron-circle-down fa-chevron-circle-up")	
			
		$('.flip').on "click", ->
		    $(this).find(".card").toggleClass("flipped flip")
		    
		    return false
		    
		$('[data-toggle="tooltip"]').tooltip();
		
		$('.carousel').carousel({interval: 5000});
		
		$('.carousel').bcSwipe({threshold: 50});
		
		
		
		$(".category").select2({
			placeholder: "Select a category",
			tags: true,
			tokenSeparators: [',']});
			
$ -> 
	_layout = new Views.Shared.Layout
	
	_layout.init()