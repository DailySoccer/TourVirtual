//
//  _MDPProfileAvatarItemModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPProfileAvatarItemModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPProfileAvatarItemModelAttributes {
	__unsafe_unretained NSString *data;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *type;
	__unsafe_unretained NSString *version;
} MDPProfileAvatarItemModelAttributes;

extern const struct MDPProfileAvatarItemModelRelationships {
	__unsafe_unretained NSString *profileAvatarPhysicalProperties;
} MDPProfileAvatarItemModelRelationships;

@class MDPProfileAvatarModel;

@interface _MDPProfileAvatarItemModel : NSManagedObject

@property (nonatomic, strong) NSString* data;

//- (BOOL)validateData:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* type;

//- (BOOL)validateType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* version;

//- (BOOL)validateVersion:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPProfileAvatarModel *profileAvatarPhysicalProperties;

//- (BOOL)validateProfileAvatarPhysicalProperties:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPProfileAvatarItemModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveData;
- (void)setPrimitiveData:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveType;
- (void)setPrimitiveType:(NSString*)value;

- (NSString*)primitiveVersion;
- (void)setPrimitiveVersion:(NSString*)value;

- (MDPProfileAvatarModel*)primitiveProfileAvatarPhysicalProperties;
- (void)setPrimitiveProfileAvatarPhysicalProperties:(MDPProfileAvatarModel*)value;

@end
