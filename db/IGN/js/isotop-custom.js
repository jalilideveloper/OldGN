$(window).load(function() {

    var $container = $('#container');

    $container.isotope({
        itemSelector: '.element'
    });

    // Infinite Scroll 
    $container.infinitescroll({
            navSelector: '#page_nav',
            nextSelector: '#page_nav a',
            itemSelector: '.element',
            behavior: 'twitter',
            maxPage: 2,
            loading: {
                msgText: '',
                finishedMsg: ''
            }
        },

        // call Isotope as a callback

        // trigger Isotope as a callback

        function(newElements) {
            // hide new items while they are loading
            var $newElems = $(newElements).css({
                opacity: 0
            });
            // ensure that images load before adding to Isotope layout
            $newElems.imagesLoaded(function() {
                // show elems now they're ready
                $newElems.animate({
                    opacity: 1
                });
                $container.isotope('appended', $newElems);
            });
        }
    );

    var $optionSets = $('#filters'),
        $optionLinks = $optionSets.find('a');

    $optionLinks.click(function() {
        var $this = $(this);
        // don't proceed if already selected
        if ($this.hasClass('selected')) {
            return false;
        }
        var $optionSet = $this.parents('#filters');
        $optionSet.find('.selected').removeClass('selected');
        $this.addClass('selected');

        // make option object dynamically, i.e. { filter: '.my-filter-class' }
        var options = {},
            key = $optionSet.attr('data-option-key'),
            value = $this.attr('data-option-value');
        // parse 'false' as false boolean
        value = value === 'false' ? false : value;
        options[key] = value;
        if (key === 'layoutMode' && typeof changeLayoutMode === 'function') {
            // changes in layout modes need extra logic
            changeLayoutMode($this, options)
        } else {
            // otherwise, apply new options
            $container.isotope(options);
        }

        return false;
    });



});
