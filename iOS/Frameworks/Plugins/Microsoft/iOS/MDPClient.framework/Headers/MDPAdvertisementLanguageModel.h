//
//  MDPAdvertisementLanguageModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPAdvertisementLanguageModel.h"


#pragma mark  - PageOrientationType
typedef NS_ENUM(NSInteger, MDPAdvertisementLanguageModelPageOrientationType) {
    MDPAdvertisementLanguageModelPageOrientationTypePortrait                    = 0,
    MDPAdvertisementLanguageModelPageOrientationTypeLandscape                   = 1,
};


#pragma mark - Interface
@interface MDPAdvertisementLanguageModel : _MDPAdvertisementLanguageModel

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
