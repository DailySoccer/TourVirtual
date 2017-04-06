//
//  _MDPProfileAvatarAccessoryItemModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPProfileAvatarAccessoryItemModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPProfileAvatarAccessoryItemModelAttributes {
	__unsafe_unretained NSString *data;
	__unsafe_unretained NSString *idVirtualGood;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *type;
	__unsafe_unretained NSString *version;
} MDPProfileAvatarAccessoryItemModelAttributes;

extern const struct MDPProfileAvatarAccessoryItemModelRelationships {
	__unsafe_unretained NSString *profileAvatarAccesories;
} MDPProfileAvatarAccessoryItemModelRelationships;

@class MDPProfileAvatarModel;

@interface _MDPProfileAvatarAccessoryItemModel : NSManagedObject

@property (nonatomic, strong) NSString* data;

//- (BOOL)validateData:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idVirtualGood;

//- (BOOL)validateIdVirtualGood:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* type;

//- (BOOL)validateType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* version;

//- (BOOL)validateVersion:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPProfileAvatarModel *profileAvatarAccesories;

//- (BOOL)validateProfileAvatarAccesories:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPProfileAvatarAccessoryItemModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveData;
- (void)setPrimitiveData:(NSString*)value;

- (NSString*)primitiveIdVirtualGood;
- (void)setPrimitiveIdVirtualGood:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveType;
- (void)setPrimitiveType:(NSString*)value;

- (NSString*)primitiveVersion;
- (void)setPrimitiveVersion:(NSString*)value;

- (MDPProfileAvatarModel*)primitiveProfileAvatarAccesories;
- (void)setPrimitiveProfileAvatarAccesories:(MDPProfileAvatarModel*)value;

@end
