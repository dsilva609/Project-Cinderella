#Usings
Namespace("Views.Album")

#Initialization
Views.Album.Index  = ->

#Implementation
class Views.Album.Index
	init: ->
#		$('#cardNameHeader').on "click", ->
#			$.get "/Card/SortPlayers", sortPreference: "Name", -> location.reload()	
#			
#		$('#rankHeader').on "click", ->
#			$.get "/Card/SortPlayers", sortPreference: "Rank", -> location.reload()	
#	

#		$('[id=deleteBtn]').on "click", ->
#			alert "nope"
#			ID = $(this).data "id"
#	
#			bootbox.dialog 
#				message: "Are you sure you want to delete this item?",
#				buttons: 
#					cancel: 
#						label: "No"
#					confirm: 
#						label: "Yes"
#						className: "btn-danger"
#						callback: ->
#							window.location.href = deleteUrl + "/" + ID
			return false

$ ->
	index = new Views.Album.Index
	
	index.init()