//
//  _MDPActionTokenModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPActionTokenModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPActionTokenModelAttributes {
	__unsafe_unretained NSString *idActionToken;
	__unsafe_unretained NSString *imageUrl;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *text;
	__unsafe_unretained NSString *thumbnailUrl;
	__unsafe_unretained NSString *token;
	__unsafe_unretained NSString *type;
} MDPActionTokenModelAttributes;

extern const struct MDPActionTokenModelRelationships {
	__unsafe_unretained NSString *userActionHistoryTokens;
} MDPActionTokenModelRelationships;

@class MDPUserActionHistoryModel;

@interface _MDPActionTokenModel : NSManagedObject

@property (nonatomic, strong) NSString* idActionToken;

//- (BOOL)validateIdActionToken:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* imageUrl;

//- (BOOL)validateImageUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* text;

//- (BOOL)validateText:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* thumbnailUrl;

//- (BOOL)validateThumbnailUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* token;

//- (BOOL)validateToken:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* type;

@property (atomic) int16_t typeValue;
- (int16_t)typeValue;
- (void)setTypeValue:(int16_t)value_;

//- (BOOL)validateType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *userActionHistoryTokens;

- (NSMutableSet*)userActionHistoryTokensSet;

@end

@interface _MDPActionTokenModel (UserActionHistoryTokensCoreDataGeneratedAccessors)
- (void)addUserActionHistoryTokens:(NSSet*)value_;
- (void)removeUserActionHistoryTokens:(NSSet*)value_;
- (void)addUserActionHistoryTokensObject:(MDPUserActionHistoryModel*)value_;
- (void)removeUserActionHistoryTokensObject:(MDPUserActionHistoryModel*)value_;
@end

@interface _MDPActionTokenModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveIdActionToken;
- (void)setPrimitiveIdActionToken:(NSString*)value;

- (NSString*)primitiveImageUrl;
- (void)setPrimitiveImageUrl:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveText;
- (void)setPrimitiveText:(NSString*)value;

- (NSString*)primitiveThumbnailUrl;
- (void)setPrimitiveThumbnailUrl:(NSString*)value;

- (NSString*)primitiveToken;
- (void)setPrimitiveToken:(NSString*)value;

- (NSNumber*)primitiveType;
- (void)setPrimitiveType:(NSNumber*)value;

- (int16_t)primitiveTypeValue;
- (void)setPrimitiveTypeValue:(int16_t)value_;

- (NSMutableSet*)primitiveUserActionHistoryTokens;
- (void)setPrimitiveUserActionHistoryTokens:(NSMutableSet*)value;

@end
