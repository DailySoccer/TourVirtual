//
//  MDPPartialUpdateModel.h
//  MDPClient
//
//  Created by LUIS PAEZ GONZALEZ on 11/3/16.
//  Copyright © 2016 Microsoft. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MDPPartialUpdateItemModel.h"


#pragma mark - Interface
@interface MDPPartialUpdateModel : NSObject


#pragma mark - Method Add
- (void)addPartialUpdateItemWithPartialUpdateItem:(MDPPartialUpdateItemModel *)partialUpdateItem;


#pragma mark - Method Get
- (NSArray *)collectionPartialUpdateItem;

@end
