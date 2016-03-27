#Usings
Namespace("Views.Record")

#Initialization
Views.Record.Index  = ->

#Implementation
class Views.Record.Index
	init: ->
#		$('#cardNameHeader').on "click", ->
#			$.get "/Card/SortPlayers", sortPreference: "Name", -> location.reload()	
#			
#		$('#rankHeader').on "click", ->
#			$.get "/Card/SortPlayers", sortPreference: "Rank", -> location.reload()	
#	
		$('[id=record]').on "click", ->
			window.location.href = detailsUrl + "/" + $(this).data "id"

		$('[id=deleteRecord]').on "click", ->
			ID = $(this).data "id"
	
			bootbox.dialog 
				message: "Are you sure you want to delete this record?",
				buttons: 
					cancel: 
						label: "No"
					confirm: 
						label: "Yes"
						className: "btn-danger"
						callback: ->
							window.location.href = deleteUrl + "/" + ID
			return false

$ ->
	index = new Views.Record.Index
	
	index.init()