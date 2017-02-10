//
//  MDPProductItemModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPProductItemModel.h"


#pragma mark - Product Type
typedef NS_ENUM(NSInteger, MDPProductItemModelProductType) {
    MDPProductItemModelProductTypeCoins             = 0,
    MDPProductItemModelProductTypeVirtualGood       = 1,
    MDPProductItemModelProductTypeSubscription      = 2,
};


#pragma mark - Interface
@interface MDPProductItemModel : _MDPProductItemModel

+ (MDPProductItemModel *)productItemWithIdItem:(NSString *)idItem managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsProductItemWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
