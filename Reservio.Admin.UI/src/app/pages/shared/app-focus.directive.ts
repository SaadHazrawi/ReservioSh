import { Directive, ElementRef, Input, Renderer2 } from '@angular/core';

@Directive({
  selector: '[ngxAppFocus]'
})
export class AppFocusDirective {
  @Input('ngxAppFocus') isFocused: boolean = false;

  constructor(private elementRef: ElementRef, private renderer: Renderer2) {}

  ngOnChanges(): void {
    if (this.isFocused) {
      this.renderer.addClass(this.elementRef.nativeElement, 'focused');
    } else {
      this.renderer.removeClass(this.elementRef.nativeElement, 'focused');
    }
  }
}
